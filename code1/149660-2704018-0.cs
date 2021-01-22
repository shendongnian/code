    public partial class MainWindow : Form
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        private void button_Click(object sender, EventArgs e)
        {
            listBox.Items.Add("Job started!");
            backgroundWorker.RunWorkerAsync();
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                // send data from the background thread
                backgroundWorker.ReportProgress(0, i);
            }
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // communicate with UI thread
            listBox.Items.Add(string.Format("Received message: {0}", e.UserState));
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox.Items.Add("Job done!");
        }
        #endregion
    }
