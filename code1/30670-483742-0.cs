    string input = "X400:C=US;A= ;P=Test;O=Exchange;S=Jack;G="
      +"Black;;smtp:jblack@test.com;SMTP:jb@test.com";
    string[] rawSplit = input.Split(';');
    List<string> result = new List<string>();
      //now the fun begins
    string buffer = string.Empty;
    foreach (string s in rawSplit)
    {
      if (buffer == string.Empty)
      {
        buffer = s;
      }
      else if (s.Contains(':'))
      {   
        result.Add(buffer);
        buffer = s;
      }
      else
      {
        buffer += ";" + s;
      }
    }
    result.Add(buffer);
    foreach (string s in result)
      Console.WriteLine(s);
