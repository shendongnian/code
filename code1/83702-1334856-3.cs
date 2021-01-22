    public partial class Form1 : Form
    {
        private Action<float> updateProgMethod;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            updateProgMethod = UpdateProgress;
        }
        private void GetDirectorySizeAsync(string path)
        {
            backgroundWorker.RunWorkerAsync(path);
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo((string)e.Argument);
            di.GetTotalSize(ProgressCallback);
        }
        // Takes callbacks from the GetTotalSize() method
        private void ProgressCallback(float p)
        {
            // Invokes update progress bar on GUI thread:
            this.BeginInvoke(updateProgMethod, new object[] { p });
        }
        // Actually updates the progress bar:
        private void UpdateProgress(float p)
        {
            progressBar.Value = (int)(p * (progressBar.Maximum - progressBar.Minimum)) + progressBar.Minimum;
        }
    }
    public static class IOExtensions
    {
        public static long GetTotalSize(this DirectoryInfo directory, Action<float> progressCallback)
        {
            FileInfo[] files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            long sum = 0;
            int countDown = 0;
            for (int i = 0; i < files.Length; i++)
            {
                sum += files[i].Length;
                countDown--;
                if (progressCallback != null && countDown <= 0)
                {
                    countDown = 100;
                    progressCallback((float)i / files.Length);
                }
            }
            return sum;
        }
    }
