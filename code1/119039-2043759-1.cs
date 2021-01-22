    private void MyForm_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
        if (files != null)
        {
            _filesToProcess.Text = files[0];  // Assuming this is declared at the Form level
            // Schedule a timer to fire in a few miliseconds as a simple asynchronous method
            _DragDropTimer.Interval = 50;
            _DragDropTimer.Enabled = true;
            _DragDropTimer.Start();
            Activate();  // Activates the form and gives it focus
        }
    }
