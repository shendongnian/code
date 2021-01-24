	public class Form1: Form
	{
		private Queen _queen;
		
		public Form1()
		{
			InitializeComponent();
			Worker[] workers = new Worker[4];
			workers[0] = new Worker(new string[] { "Nectar Collector", "Honey Manufacturing" });
			workers[1] = new Worker(new string[] { "Egg Care", "Baby Bee Tutoring" });
			workers[2] = new Worker(new string[] { "Hive Maintenance", "Sting Patrol" });
			workers[3] = new Worker(new string[] { "Nectar Collector", "Honey Manufacturing", "Egg Care", "Baby Bee Tutoring", "Hive Maintenance", "Sting Patrol" });
			_queen = new Queen(workers);
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			if(_queen.AssignWork(workerBeeJob.Text, (int)shifts.Value))
			{
				MessageBox.Show("The job '" + workerBeeJob.Text + "` will be done in");
			}
		}
	}
