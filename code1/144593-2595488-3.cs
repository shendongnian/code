    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileName,
                                           Encoding.GetEncoding("iso-8859-1")))
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(
                                               outFileName, Encoding.UTF8))
        {
            writer.Write(reader.ReadToEnd());
        }
    }
