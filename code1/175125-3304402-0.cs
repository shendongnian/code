        void DoSomethingWithStream()
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(@"C:\test.txt", System.IO.FileMode.Open);
                try
                {
                    // do something with the file stream
                }
                catch (Exception ex)
                {
                    // handle exceptions caused by reading the stream,
                    // if these need to be handled separately from exceptions caused by opening the stream
                }
                finally
                {
                    // FileStream.Close might throw an exception, so put FileStream.Dispose in a separate try/finally
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                // handle exceptions that were either thrown by opening the filestream, thrown by closing the filestream, or not caught by the inner try/catch
            }
        }
