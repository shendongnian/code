    if (!File.Exists(path))
    {
        using (var stream = File.Create(path))
        {
            using (TextWriter tw = new StreamWriter(stream))
            {
                tw.WriteLine("abc");
                tw.Close();
            }
        }
    }
