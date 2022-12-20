using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_11_Forms_N4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if(textBox1.Text == "")
				{
					DataWork data = new DataWork();
					textBox1.Text = string.Format(data.DateValue);
					textBox2.Text = string.Format(data.LastDay(data.date));
					textBox3.Text = string.Format(data.NextDay(data.date));
					textBox4.Text = Convert.ToString(data.DaysLeft(data.date));
					if (data.LeapYear)
					{
						textBox5.Text = string.Format("високосный.");
					}
					else
					{
						textBox5.Text = string.Format("не високосный.");
					}
				}
				else
				{
					DateTime setDate = DateTime.Parse(textBox1.Text);
					DataWork data1 = new DataWork(setDate);
					textBox1.Text = string.Format(data1.DateValue);
					textBox2.Text = string.Format(data1.LastDay(data1.date));
					textBox3.Text = string.Format(data1.NextDay(data1.date));
					textBox4.Text = Convert.ToString(data1.DaysLeft(data1.date));
					if (data1.LeapYear)
					{
						textBox5.Text = string.Format("високосный.");
					}
					else
					{
						textBox5.Text = string.Format("не високосный.");
					}
				}
			}
			catch (FormatException)
			{
				MessageBox.Show("Неверный ввод данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch
			{
				MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
	class DataWork
	{
		public DateTime date;

		public DataWork()
		{
			date = new DateTime(2009, 1, 1);
		}

		public DataWork(DateTime date)
		{
			this.date = date;
		}

		public string LastDay(DateTime date)
		{
			DateTime ldate = date.AddDays(-1);
			return ldate.ToShortDateString();
		}

		public string NextDay(DateTime date)
		{
			DateTime ndate = date.AddDays(1);
			return ndate.ToShortDateString();
		}

		public int DaysLeft(DateTime date)
		{
			int dLeft = DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
			return dLeft;
		}

		public string DateValue
		{
			get
			{
				return date.ToShortDateString();
			}
			set
			{
				date = DateTime.Parse(value);
			}
		}

		public bool LeapYear
		{
			get
			{
				if (date.Year % 4 == 0)
					return true;
				else
					return false;
			}
		}
	}
}
