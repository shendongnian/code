	public partial class TaskProgress : Form
	{
		private string parameter = null;
		private string parameter2 = null;
		private string parameter3 = null;
		
		public TaskProgress(string parameter, string parameter2, string parameter3)
		{
			InitializeComponent();
			this.parameter = parameter;
			this.parameter2 = parameter2;
			this.parameter3 = parameter3;
		}
	
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			function1(this.parameter1);
			backgroundWorker1.ReportProgress(20);
			function2(this.parameter2);
			backgroundWorker1.ReportProgress(60);
			function3(this.parameter3);
			backgroundWorker1.ReportProgress(100);
		}
	}
