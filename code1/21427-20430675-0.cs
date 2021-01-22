            for (int attempts = 0; attempts < 10; attempts++)
            {
                try
                {
                    if (Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true);
                    }
                    return;
                }
                catch (IOException e)
                {
                    GC.Collect();
                    Thread.Sleep(1000);
                }
            }
            throw new Exception("Failed to remove folder.");
