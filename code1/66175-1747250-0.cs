    using (LiveJob job = new LiveJob())
                {
                    // Create a new file source from the file name we were passed in
                    LiveFileSource fileSource = job.AddFileSource(fileToEncode);
    
                    // Set this source to Loop when finished
                    fileSource.PlaybackMode = FileSourcePlaybackMode.Loop;
    
                    // Make this source the active one
                    job.ActivateSource(fileSource);
    
                    // Create a new windows media broadcast output format so we
                    // can broadcast this encoding on the current machine.
                    // We are going to use the default audio and video profiles
                    // that are created on this output format.
                    WindowsMediaBroadcastOutputFormat outputFormat = new WindowsMediaBroadcastOutputFormat();
    
                    // Let's broadcast on the local machine on port 8080
                    outputFormat.BroadcastPort = 8080;
    
                    // Set the output format on the job
                    job.OutputFormat = outputFormat;
    
                    // Start encoding
                    Console.Out.Write("Press 'x' to stop encoding...");
                    job.StartEncoding();
    
                    // Let's listen for a keypress to know when to stop encoding
                    while (Console.ReadKey(true).Key != ConsoleKey.X)
                    {
                        // We are waiting for the 'x' key
                    }
    
                    // Stop our encoding
                    Console.Out.WriteLine("Encoding stopped.");
                    job.StopEncoding();
                }
