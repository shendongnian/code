    public partial class MyForm : Form
    {
        private void InvokeViaBgw(Action action)
        {
            BGW.ReportProgress(0, action);
        }
    
        private void BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!this.IsDisposed) //You are on the UI thread now, so no race condition
                this.Invoke((Action)e.UserState);
        }
    
        private private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
           //Sample usage:
           this.InvokeViaBgw(() => MyTextBox.Text = "Foo");
        }
    }
