    public static string EscapeAlertMessage(string value)
    {
      value = value.Replace("\\", "\\\\");
      value = value.Replace("'", "\\'");
      value = value.Replace("\"", "\\\"");
      value = value.Replace(Environment.NewLine, "--");
    
      return value;
    }
 
