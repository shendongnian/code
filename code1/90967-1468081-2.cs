    public static string MagicFunctionIO(this string self, string prefix)
    {
      string terminator = self.GetLineTerminator();
      using (StringWriter writer = new StringWriter())
      {
        using (StringReader reader = new StringReader(self))
        {
          bool first = true;
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            if (!first)
              writer.Write(terminator);
            writer.Write(prefix + line);
            first = false;
          }
          return writer.ToString();
        }
      }
    }
         
    public static string GetLineTerminator(this string self)
    {
      if (self.Contains("\r\n")) // windows
        return "\r\n";
      else if (self.Contains("\n")) // unix
        return "\n";
      else if (self.Contains("\r")) // mac
        return "\r";
      else // default, unknown env or no line terminators
        return Environment.NewLine;
    }
