    private static void BuildTableHeader(StringBuilder sb, Type p)
    {
        sb.AppendLine("<tr>");
        
        TableProperty tp = p.GetCustomAttributes(typeof(TableProperty), true)[0];
        
        foreach (var property in p.GetProperties())
            if (tp.IsPropertyAllowed(property.Name))
                sb.AppendFormat("<th>{0}</th>", property.Name);
