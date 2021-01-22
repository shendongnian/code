    long count = 0;
    using (StreamReader r = new StreamReader("file.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            count++;
        }
    }
