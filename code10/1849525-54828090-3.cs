     private static readonly object locker = new object();
    lock (locker)
                {
                    using (FileStream fileStream = new FileStream("FilePath"), FileMode.Append))
                    {
                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            writer.WriteLine(log);
                        }
                    }
                }
