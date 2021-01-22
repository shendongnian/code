            DateTime EndTime = System.DateTime.Now.AddMinutes((double)timeOut);
            while (System.DateTime.Now <= EndTime)
            {
                try
                {
                    using (Stream stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        if (stream != null)
                        {
                            break;
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    //
                }
                catch (IOException)
                {
                    //
                }
                catch (UnauthorizedAccessException)
                {
                    //
                }
               
                System.Threading.Thread.Sleep(sleepTime);
            }
