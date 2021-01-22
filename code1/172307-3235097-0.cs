    private string Loadfile(string filePath)
    {
      string text = String.Empty;
      if (File.Exists(filePath))
      {
        StreamReader streamReader = new StreamReader(filePath);
        text = streamReader.ReadToEnd();
        streamReader.Close();
      }
      return text;
    }
