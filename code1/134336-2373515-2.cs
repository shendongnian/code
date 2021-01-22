    private static void WriteToFile()
    {
        for (int i = 0; i < 100; i++)
        {
            FileStream writeFile = File.Open(
                "test.txt",
                FileMode.Append,
                FileAccess.Write,
                FileShare.Read);
    
            using (FileStream file = writeFile)
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(i);
                    Thread.Sleep(100);
                }
            }
        }
    }
