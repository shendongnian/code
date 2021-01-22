    var sBuilder = new StringBuilder()
    bool lineEnd = false;
    var items = new List<string>();
    string currentLine = String.Empty
    using(var file = new StringReader("log.txt"))
    {
      while( (currentLine = file.ReadLine()) != null)
      {
        if(currentLine.EndsWith("===="))
        {
            items.Add(sBuilder.ToString());
            sBuilder.Clear();
        }
        else
            sBuilder.Append(currentLine);
      }
    }
