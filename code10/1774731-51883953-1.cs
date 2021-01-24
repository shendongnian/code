	public partial class Alerts : Form
	{
		public Alerts()
		{
			InitializeComponent();
			// set up BackgroundWorker once
			backgroundWorker1.DoWork += OnDoWork;
			backgroundWorker1.RunWorkerCompleted += OnRunWorkerCompleted;
			// set the timer and start it running
			timer1.Interval = 5000;
			timer1.Start();
			timer1.Tick += (o, e) => backgroundWorker1.RunWorkerAsync();
		}
		// This method will run in the background every five seconds. It can't
		// access parts of the form since it is on a background thread.
		private void OnDoWork(object sender, DoWorkEventArgs e)
		{
			using (MySqlConnection conDataBase = new MySqlConnection(connectionString))
			using (MySqlCommand cmdDataBase = new MySqlCommand(" select * from shopmanager.alerts;", conDataBase))
			{
				conDataBase.Open();
				MySqlDataAdapter sda = new MySqlDataAdapter { SelectCommand = cmdDataBase };
				DataTable dbdataset = new DataTable();
				sda.Fill(dbdataset);
				// return the results to the main form thread through this property
				e.Result = dbdataset;
			}
		}
		void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// This will run on the main form thread when the background work is
			// done; it connects the results to the data grid.
			dataGridView1.DataSource = e.Result;
		}
	}
