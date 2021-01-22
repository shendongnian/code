    public void SpawnPizzaProgressBarForm(object sender, EventArgs e)
    {
        FormPizzaProgressBar Form = new FormPizzaProgressBar();
        Form.ShowDialog();
    }
    
    ...
    
    BackgroundWorker worker = new BackgroundWorker();
    
    public void ProgressBarForm_Load(object sender, EventArgs e)
    {
        // Initialize the background worker.
        worker = new BackgroundWorker();
    
        // Indicate that the worker supports progress.
        worker.WorkerSupportsProgress = true;
    
        // Subscribe to the DoWork event.
        worker.DoWork += (s, e) => {
            // Create the pizza instance.
            Pizza = new Pizza();
    
            // Process the slices.
            foreach (var Slice in Pizza)
            {
                // Clear the slice.
                Slice.Clear();
    
                // Report the progress.
                worker.ReportProgress(Slice.Index / Pizza.Count() * 100);
            }
        };
    
        // Subscribe to the ProgressChanged event.
        worker.ProgressChanged = (s, e) => {
            // Update the progress bar.
            PizzaEatingProgressBar.Value = e.ProgressPercentage;
        };
    
        // Subscribe to the RunWorkerCompleted event.
        worker.RunWorkerCompleted = (s, e) => {
            // Close the dislog.
            this.Close();
        };
    }
    
    // Must override to properly dispose of the background worker.
    protected override void Dispose(bool disposing)
    {
        // Call the base.
        base.Disposing(disposing);
    
        // Dispose of the background worker if disposing is true.
        if (disposing) worker.Dispose();
    }
