    public partial class MultithreadingForm : Form
    {
        public MultithreadingForm()
        {
            InitializeComponent();
        }
        // a simple button event handler that starts a worker thread
        private void btnDoWork_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(WorkerMethod);
            t.Start();
        }
        private void ReportProgress(string message)
        {
            // check whether or not the current thread is the main UI thread
            // if not, InvokeRequired will be true
            if (this.InvokeRequired)
            {
                // create a delegate pointing back to this same function
                // the Invoke method will cause the delegate to be invoked on the main UI thread
                this.Invoke(new Action<string>(ReportProgress), message);
            }
            else
            {
                // txtOutput is a UI control, therefore it must be updated by the main UI thread
                if (string.IsNullOrEmpty(this.txtOutput.Text))
                    this.txtOutput.Text = message;
                else
                    this.txtOutput.Text += "\r\n" + message;
            }
        }
        // a generic method that does work and reports progress
        private void WorkerMethod()
        {
            // step 1
            // ...
            ReportProgress("Step 1 completed");
            // step 2
            // ...
            ReportProgress("Step 2 completed");
            // step 3
            // ...
            ReportProgress("Step 3 completed");
        }
    }
