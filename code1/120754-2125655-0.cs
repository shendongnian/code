    public partial class Form1 : Form
    {
        private bool completedInTime = false;
        private HttpWebRequest request = null;
        public delegate void RequestCompletedDelegate(bool completedSuccessfully);
        private static AutoResetEvent resetEvent = new AutoResetEvent(false);
        private System.Threading.Timer timer = null;
        private static readonly object lockOperation = new object();
        public Form1()
        {
            InitializeComponent();
            urlTextBox.Text = "http://twitter.com";
            millisecondsTextBox.Text = "10000";
        }
        private void handleUIUpdateRequest(bool completedSuccessfully)
        {
            resultCheckbox.Checked = completedSuccessfully;
            startTestButton.Enabled = true;
            completedInTime = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            startTestButton.Enabled = false;
            try
            {
                TestWebServiceConnection(urlTextBox.Text,
                    Convert.ToInt32(millisecondsTextBox.Text));
                resetEvent.WaitOne();
                resultCheckbox.BeginInvoke(new RequestCompletedDelegate(handleUIUpdateRequest), completedInTime);
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception ex)
            {
            }
        }
        private void TestWebServiceConnection(string url, int timeoutMilliseconds)
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
            timer = new System.Threading.Timer(new TimerCallback(abortRequest), null, timeoutMilliseconds, Timeout.Infinite);
        }
        private void FinishWebRequest(IAsyncResult iar)
        {
                lock (lockOperation)
                {
                    completedInTime = true;
                    resetEvent.Set();
                }
                
                /*
                if (timer != null)
                {
                    timer.Dispose();
                    try
                    {
                        if (request != null)
                        {
                            request.Abort();
                        }
                    }
                    catch { }
                }
                timer = null;
                request = null;
                 
            }
                 * */
        }
        private void abortRequest(object state)
        {
            lock (lockOperation)
            {
                resetEvent.Set();
            }
            try
            {
                Thread.CurrentThread.Abort();
            }
            catch {}
            /*
            lock (lockOperation)
            {
                if (!completedInTime)
                {
                    resetEvent.Set();
                }
            }
            
            if (completedInTime == false)
            {
                lock (lockOperation)
                {
                    completedInTime = false;
                }
                try
                {
                    if (request != null)
                    {
                        request.Abort();
                    }
                }
                catch { }
                try
                {
                    if (timer != null)
                    {
                        timer.Dispose();
                    }
                }
                catch { }
                finally
                {
                    resetEvent.Set();
                }
                request = null;
                timer = null;
             
            }
             * */
        }
    }
}
