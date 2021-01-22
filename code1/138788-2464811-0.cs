    class MyForm : Form
    {
        private Label label = new Label();
    
        private void DoWork()
        {
            // Do work ... Not in UI thread
    
            // Update label... In UI thread
            this.Invoke(new MethodInvoker(() => label.Text = "New Text!"));
        }
    }
