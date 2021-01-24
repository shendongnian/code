    public string GetHtml(DataTable table3)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<table>");
        foreach(var row in table3.Rows) 
        {
            sb.AppendLine("    <tr>");
            sb.AppendLine($"        <td>{row["id"]}</td>");
            sb.AppendLine($"        <td>{row["name"]}</td>");
            sb.AppendLine($"        <td>{row["amntOne"]}</td>");
            sb.AppendLine($"        <td>{row["amntTwo"]}</td>");
            sb.AppendLine($"        <td>{row["location"]}</td>");
            sb.AppendLine("    </tr>");
        }
        sb.AppendLine("</table>");
        return sb.ToString();
    }
   
