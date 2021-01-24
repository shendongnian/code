    public class ParentForm : Form
    {
        private void ParentForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            new Form1().ShowDialog(); // execution waits until form is closed
            
            // now wait for worker to finish
            while (Background.Worker.IsBusy)
            {
                Background.ResetEvent.WaitOne(5000); // Waits 5 seconds for the event
            }
    }
