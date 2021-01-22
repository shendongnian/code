    public static void CopyStream(Stream input, Stream output)
    {
      using (StreamReader reader = new StreamReader(input))
      using (StreamWriter writer = new StreamWriter(output))
      {
        writer.Write(reader.ReadToEnd());
      }
    }
