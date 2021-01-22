    var query = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
                from row in table.SelectNodes("tr").Cast<HtmlNode>()
                from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                select new {Table = table.Id, CellText = cell.InnerText};
    
    foreach(var cell in query) {
        Console.WriteLine("{0}: {1}", cell.Table, cell.CellText);
    }
