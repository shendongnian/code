     public static string XmlDecode(string encodedString)
      {
          var workingBuffer = new StringBuilder(encodedString);
          workingBuffer.Replace("&lt;", "<")
              .Replace("&gt;", ">")
              .Replace("&quot;", "\"")
              .Replace("&apos;", "'")
              .Replace("&amp;", "&");
          return workingBuffer.ToString();
      }
