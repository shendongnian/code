    using (StreamReader sr = new StreamReader(path, appropriateEncoding))
    {
        string line;
        while ( (line = sr.ReadLine()) != null)
        {
            // ...
        }
    }
