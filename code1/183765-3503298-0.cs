    private string GetFileName(string str) 
    {
      if ( string.IsNullOrEmpty(str) return string.Empty;
    
      string inputString = textBox2.Text.ToString();    
      string last = inputString.Substring(inputString.LastIndexOf('\\') + 1);    
      return last.Split('.');    
    }
