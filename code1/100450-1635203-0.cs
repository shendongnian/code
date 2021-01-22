            ThreadPool.UnsafeQueueUserWorkItem(ignoredState =>
            {
                Stream stream = null;
                try
                {
                    stream = new FileStream("HighScores.dat", System.IO.FileMode.Create, FileAccess.Write);
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(stream, "Test String");
                }
                catch (Exception e)
                {
                    logger.Error("Error writing high scores:", e);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }, null);
