    public partial class MyForm : Form
    {
        private void InvokeViaBgw(Action action)
        {
            BGW.ReportProgress(0, action);
        }
    
        private void BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.IsDisposed) return; //You are on the UI thread now, so no race condition
            var action = (Action)e.UserState;
            action();
        }
    
        private private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
           //Sample usage:
           this.InvokeViaBgw(() => MyTextBox.Text = "Foo");
        }
    }
