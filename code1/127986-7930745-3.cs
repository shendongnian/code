    public static string ScrubFileName(string value)
    {
       var sb = new StringBuilder(value);
       foreach (char item in Path.GetInvalidFileNameChars())
       {
          sb.Replace(item.ToString(), "");
       }
       return sb.ToString();
    }
