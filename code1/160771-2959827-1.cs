    private string CreateSQL(List<string> names)
    {
        var sb = new StringBuilder();
        sb.Append("select city,count(*) from table where user in ('");
        foreach ( var name in name)
        {
           sb.Append("'");
           sb.Append(name);
           sb.Append("',");
        }
        sb.Remove(sb.Length-1,1); //remove trailing ,
        sb.Append(") GROUP BY city");
        
        return sb.ToString();
    }
