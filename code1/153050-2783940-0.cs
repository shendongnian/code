    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace tester
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
    
            /// <summary>
            /// This delegate enables asynchronous calls for setting the text property on a control.
            /// </summary>
            delegate void SetTextCallback(string status);
    
            private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
            {
                for (var i = 0; i < 100; i++)
                {
                    backgroundWorker1.ReportProgress(i);
                    Thread.Sleep(100);
                }
            }
    
            private void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                if (label1.InvokeRequired)
                    Invoke(new SetTextCallback(SetLabelText), new object[] { e.ProgressPercentage.ToString()});
                else
                    SetLabelText(e.ProgressPercentage.ToString());
            }
    
            private void SetLabelText(string text)
            {
                label1.Text = text;
            }
        }
    }
