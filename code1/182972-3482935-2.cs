    public void StartLongProcess()
    {
        // Create and show the form with the progress bar
        var progressForm = new Subform();
        progressForm.Show();
        bool interrupt = false;
        // Run the calculation in a separate thread
        var thread = new Thread(() =>
        {
            // Do some calculation, presumably in some sort of loop...
            while ( ... )
            {
                // Every time you want to update the progress bar:
                progressForm.Invoke(new Action(
                    () => { progressForm.ProgressBar.Value = ...; }));
    
                // If you’re ready to cancel the calculation:
                if (interrupt)
                    break;
            }
            // The calculation is finished — close the progress form
            progressForm.Invoke(new Action(() => { progressForm.Close(); }));
        });
        thread.Start();
        // Allow the user to cancel the calculation with a Cancel button
        progressForm.CancelButton.Click += (s, e) => { interrupt = true; };
    }
