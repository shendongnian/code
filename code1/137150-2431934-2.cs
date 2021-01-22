    private static DataTable[] ParseAllTables(HtmlDocument doc)
    {
        var result = new List<DataTable>();
        foreach (var table in doc.DocumentNode.Descendants("table"))
        {
            result.Add(ParseTable(table));
        }
        return result.ToArray();
    }
    
    private static DataTable ParseTable(HtmlNode table)
    {
        var result = new DataTable();
    
        var rows = table.Descendants("tr");
    
        var header = rows.Take(1).First();
        foreach (var column in header.Descendants("td"))
        {
            result.Columns.Add(new DataColumn(column.InnerText, typeof(string)));
        }
    
        foreach (var row in rows.Skip(1))
        {
            var data = new List<string>();
            foreach (var column in row.Descendants("td"))
            {
                data.Add(column.InnerText);
            }
            result.Rows.Add(data.ToArray());
        }
        return result;
    }
