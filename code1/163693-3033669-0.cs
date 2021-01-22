    using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Threading;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			public class ThreadWork
			{
				public static void DoWork()
				{
					serialPort1.Open();
					serialPort1.Write("AT+CMGF=1\r\n");
					//Thread.Sleep(500);
					serialPort1.Write("AT+CNMI=2,2\r\n");
					//Thread.Sleep(500);
					serialPort1.Write("AT+CSCA=\"+4790002100\"\r\n");
					//Thread.Sleep(500);
					serialPort1.DataReceived += serialPort1_DataReceived_1;
				}
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				ThreadStart myThreadDelegate = new ThreadStart(ThreadWork.DoWork);
				Thread myThread = new Thread(myThreadDelegate);
				myThread.Start();
			}
			private void serialPort1_DataReceived_1(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
			{
				string response = serialPort1.ReadLine();
			this.BeginInvoke(new MethodInvoker(() => textBox1.AppendText(response + "\r\n")));
			}
		}
	}
