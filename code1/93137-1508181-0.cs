    public static IEnumerable<string> ReadLines(this Stream stream)
    {
        StreamReader rdr = new StreamReader(stream);
        try
        {
            string txt = rdr.ReadLine();
            while (txt != null)
            {
                yield return txt;
                txt = rdr.ReadLine();
            }
            rdr.Close();
        }
        finally
        {
            rdr.Dispose();
        }
    }
