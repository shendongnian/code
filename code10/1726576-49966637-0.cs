    public partial class Form1 : Form
    {
        event EventHandler ReportProgress;
        class ProgressEvent : EventArgs
        {
            public int Total { get; set; }
            public int Current { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            ReportProgress += Form1_ReportProgress;
        }
        private void Form1_ReportProgress(object sender, EventArgs e)
        {
            var progress = e as ProgressEvent;
            this.Invoke(new Action(() =>
                                   {
                                       progressBar.Maximum = progress.Total;
                                       progressBar.Value = progress.Current;
                                   }));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Collect data from UI, I use list for example
            List<int> values = new List<int>() { };
            values.AddRange(Enumerable.Range(1, 100));
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            backgroundWorker.RunWorkerAsync(values);
        }
        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            var values = (IEnumerable<int>) doWorkEventArgs.Argument; // the 'argument' parameter resurfaces here
            var total = values.Count();
            var current = 0;
            Parallel.ForEach(values, v =>
                                     {
                                         Interlocked.Increment(ref current);
                                         var r = new Random(v);
                                         // Just sleep a little
                                         var sleep = r.Next(10, 1000);
                                         Thread.Sleep(sleep);
                                         // Update the progress bar
                                         ReportProgress(null, new ProgressEvent() {Current = current, Total = total});
                                     }
                            );
            MessageBox.Show("Done ");
        }
    }
