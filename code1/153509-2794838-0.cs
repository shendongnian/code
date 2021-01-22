        public partial class Form1 : Form
        {
            public event EventHandler<DownloaderProgressArgs> OnDownloadProgress;
            public event EventHandler<DownloaderProgressArgs> OnDownloadSpeed;
            public Form1()
            {
                InitializeComponent();
                OnDownloadProgress += GetInvokeRequiredDelegate<DownloaderProgressArgs>(DownloadProgress);
                OnDownloadSpeed += GetInvokeRequiredDelegate<DownloaderProgressArgs>(DownloadSpeed);
                new System.Threading.Thread(Test).Start();
            }
            public void Test()
            {
                OnDownloadProgress(this, new DownloaderProgressArgs() { DownloadSpeed = 1000, speedOutput = 5 });
                OnDownloadSpeed(this, new DownloaderProgressArgs() { DownloadSpeed = 2000, speedOutput = 10 });
            }
            EventHandler<T> GetInvokeRequiredDelegate<T>(Action<object, T> action) where T : EventArgs
            {
                return ((o, e) =>
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(action, new object[] { o, e});
                    } else 
                    {
                        action(o, e);
                    }
                });
            }
            
            void DownloadProgress(object sender, DownloaderProgressArgs d)
            {
                label2.Text = d.speedOutput.ToString();
            }
            void DownloadSpeed(object sender, DownloaderProgressArgs e)
            {
                string speed = "";
                speed = (e.DownloadSpeed / 1024).ToString() + "kb/s";
                label3.Text = speed;
            }
        }
        public class DownloaderProgressArgs : EventArgs {
            public int DownloadSpeed;
            public int speedOutput;
        }
