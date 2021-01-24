	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i < 5; ++i)
			{
				this.Invoke(new Action(() => textBox1.AppendText("1")));
				Thread.Sleep(500);
			}
			var f2 = new Form2();
			if(f2.ShowDialog(this) == DialogResult.OK)
				this.Invoke(new Action(() => textBox1.AppendText("2")));
			else
				this.Invoke(new Action(() => textBox1.AppendText("3")));
			for (int i = 0; i < 100; ++i)
			{
				this.Invoke(new Action(() => textBox1.AppendText("1")));
				Thread.Sleep(500);
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			backgroundWorker1.RunWorkerAsync();
		}
	}
