    StringBuilder sb = new StringBuilder();
    string element="?";
    string sep=",";
    int n=4;
    
    for (int x = 0; x < n; x++)
    {
        sb.Append(element);
        sb.Append(sep);
    }
    
    if (sb.Length > 0)
    {
        // remove the final separator
        sb.Length -= sep.Length;
    }
    
    Console.WriteLine(sb.ToString());
