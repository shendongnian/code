    using (FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
    {
        using(StreamReader sr = new System.IO.StreamReader(fs))
        {
            res = sr.ReadToEnd();
        }
    }
