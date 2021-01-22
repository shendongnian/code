        void DoSomethingWithStream_PartDeux()
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(@"C:\test.txt", System.IO.FileMode.Open);
                try
                {
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
                        fs.Close();
                    }
                }
                finally
                {
                    // FileStream.Close might throw an exception, so put FileStream.Dispose in a separate try/finally
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                // handle exceptions
            }
        }
