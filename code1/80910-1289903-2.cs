    public partial class Form1 : Form
    {
        private void ReportProgresshandler(int percent, string state)
        {
            backgroundWorker1.ReportProgress(percent);  // also does the Invoke
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var ex = new ExampleClass();
            ex.Dowork(ReportProgresshandler);    
        }
    }
