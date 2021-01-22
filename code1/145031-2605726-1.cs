    private static void ParseTable(HtmlNode table, ref DataTable data)
    {
       // do the parse, fill bool gotTable 
       data = gotTable ? new DataTable() : null;
    }
    private static void ParseTable(HtmlNode table)
    {
       ParseTable(table, out null);
    }
