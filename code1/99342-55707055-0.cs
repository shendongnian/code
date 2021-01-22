    private void ProcessFileHandler(object sender, ProgressEventArgs e)
            {                    
                    ZipEntry newEntry = sender as ZipEntry;
                    if (newEntry != null)
                    {
                        newEntry.Size = e.Processed;
                    }
                    e.ContinueRunning = keepRunning;
                    return;
             }
