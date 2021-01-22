    MatchCollection mc = Regex.Matches(inText, "\"\\w+?\"");
    
    StringBuilder sb = new StringBuilder();
    sb.Append("{");
    
    for(int i = 0;i < mc.Count;i++)
    {
      sb.Append(mc[i].Groups[0].Value);
      if(i != mc.Count-1)
      {
        sb.Append(",");
      }
    }
    
    sb.Append("}");
