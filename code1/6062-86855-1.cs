    StreamReader reader = file.OpenText();
    try
    {
       List<string> text = new List<string>();
       while (!reader.EndOfStream)
       {
          text.Add(reader.ReadLine());
       }
    }
    finally
    {
       if (reader != null)
          ((IDisposable)reader).Dispose();
    }
