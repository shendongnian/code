    public partial class ProgressForm : Form {
        // Assuming you have put all required controls on design...
        // Allowing some properties to be exposed for progress update...
        public properties MaximumProgress { 
            set {
                progressBar1.Maximum = value;
            }
        public properties OverallProgress { 
            set {
                progressBar1.Value = value;
            }
    }
    public partial class MainForm : Form {
        private BackgroundWorker backgroundWorker1;
        private ProgressForm _pf;
        public MainForm() {
            InitializeComponent();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }
        // Assuming process starts on Button click.
        private void button1_Click(object sender, EventArgs e) {
            _pf = new ProgressForm();
            _pf.MaximumProgress = number-of-elements-to-treat-returned-by-prevision-or-whatever-else;
            // Launching the background workder thread.
            backgroundWorker1.RunWorkerAsync(); // Triggering the DoWork event.
            // Then showing the progress form.
            _pf.ShowDialog();
        }
        private void backgroundWorker1_DoWork(object sender, EventArgs e) {
            LaunchProcess();
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            _pf.OverallProgress = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, EventArgs e) {
            _pf.Close();
            _pf.Dispose();
        }
        private void LaunchProcess() {
            // Do some work here...
            // Reporting progress somewhere within the processed task
            backgroundWorker1.ReportProgress();
        }
    }
