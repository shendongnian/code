    string para = "ABC,444,CD-EF,90-BA,HIJ";
    StringBuilder sb = new StringBuilder("SELECT * FROM table WHERE ");
    List<string> queries = new List<string>();
    foreach (var part in para.Split(','))
    {
        if (part.Contains("-"))
        {
            var between = part.Split('-');
            queries.Add(string.Format("Col1 BETWEEN '{0}' AND '{1}'", between[0], between[1]));
        }
        else
        {
            queries.Add(string.Format("Col1 = '{0}'", part));
        }
    }
    sb.Append(string.Join(" OR ", queries.ToArray()));
    string sql = sb.ToString();
