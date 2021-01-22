    // Get the synchronization context.
    // This is in the UI thread.
    SynchronizationContext sc = SynchronizationContext.Current;
    
    // Create the thread, but use the SynchronizationContext
    // in the closure to marshal the call back.
    Thread t = new Thread(delegate()  
    {  
        // Do your work.
        po.Organise(inputPath, outputPath, recursive);  
        // Call back using the SynchronizationContext.
        // Can call the Post method if you don't care
        // about waiting for the result.
        sc.Send(delegate()
        {
            // Fill the progress bar.
            PBar.Value = 100;
        });
    }); 
    // Make the progress bar indeterminate.
    PBar.IsIndeterminate = true;
    
    // Start the thread.
    t.Start(); 
     
