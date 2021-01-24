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
		private void OnDoWork(object sender, DoWorkEventArgs e)
		{
			using (MySqlConnection conDataBase = new MySqlConnection(connectionString))
			using (MySqlCommand cmdDataBase = new MySqlCommand(" select * from shopmanager.alerts;", conDataBase))
			{
				conDataBase.Open();
				MySqlDataAdapter sda = new MySqlDataAdapter { SelectCommand = cmdDataBase };
				DataTable dbdataset = new DataTable();
				sda.Fill(dbdataset);
				e.Result = dbdataset;
			}
		}
		void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			dataGridView1.DataSource = e.Result;
		}
	}
