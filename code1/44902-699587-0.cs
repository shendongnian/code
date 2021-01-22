Or another option would be to have a while loop checking whether the file can be opened with write access. If it can you will know that copying has been completed. C# code could look like this (in a production system you might want to have a maximum number of retries or timeout instead of a while(true)):
    /// <summary>
    /// Waits until a file can be opened with write permission
    /// </summary>
    public static void WaitReady(string fileName)
    {
        while (true)
        {
            try
            {
                using (Stream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    if (stream != null)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} ready.", fileName));
                        break;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
            }
            catch (IOException ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
            }
            Thread.Sleep(500);
        }
    }
