    StreamWriter sw;
    try
    {
        StreamWriter sw = new StreamWriter(ms, Encoding.Default, 1024, true);
        foreach (String s in content)
            sw.WriteLine(s);
    }
    finally
    {
        if(sw != null)
            sw.Dispose();
    }
