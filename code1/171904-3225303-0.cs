    string Delimiter = "||"; 
    string[] columns = fileString.Substring(0, fileString.IndexOf(Environment.NewLine))
       .Split(new string[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries); 
    string[] cells = fileString.Substring(fileString.IndexOf(Environment.NewLine))
       .Split(new string[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries); 
    List<string> rows = new List<string>();
    StringBuilder row = new StringBuilder();
    int colIndex = 0;
    int breakIndex = columns.Length;
    char[] trimChars = new char[] { '\r','\n',' ' };
    foreach(string c in cells)
    {
       if (cellIndex == breakIndex)
       {
           rows.Add(row.ToString().Trim(trimChars));
           cellIndex = 0;
           row = new StringBuilder();
       }
       row.Append(c).Append(" ");
       cellIndex ++;
    }
    rows.Add(row.ToString().Trim(trimChars));
    
