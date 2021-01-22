    IEnumerable<string> GetInvoiceNumbers()
    {
        string path = @"C:\Users\sam\Documents\GCProg\testReadFile.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
               yield return sr.ReadLine();
            }
        }
    }
