    public partial class Form1 : Form
    {
        private bool closing;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            closing = true;
            base.OnFormClosing(e);
        }
        private void Save()
        {
            Background.WorkerAction = () =>
            {
                // your saving logic here
            };
            Background.Worker.RunWorkerAsync();
            while (!closing && Background.Worker.IsBusy)
            {
                Background.WorkerResetEvent.WaitOne(500); // wait half a second at a time (up to you)
                
                // any logic to update progress bar or other progress indicator
                Refresh() // Update the screen without costly DoEvents call
            }
        }
    }
