     private void CreateTable()
     {
        Table table = new Table();
    
        TableRow tr = new TableRow();
    
        //film name
        tr.Cells.Add(GetTableCell("Film Name"));
    
        //director
        tr.Cells.Add(GetTableCell("Director Name"));
    
        //actor
        tr.Cells.Add(GetTableCell("Actor Name"));
    
        //film year
        tr.Cells.Add(GetTableCell("Film Year"));
    
        //film link
        HyperLink link = new HyperLink();
        link.NavigateUrl = "https://www.imdb.com/title/tt4154756/";
        link.Text = "Film Name";
    
        tr.Cells.Add(GetTableCell(link));    
 
        table.Rows.Add(tr);
    }
    
    //returns new table cell with text content
    private TableCell GetTableCell(string text)
    {
        TableCell tc = new TableCell();
        tc.Text = text;
    
        return tc;
    }
    
    //returns new table cell with hyperlink
    private TableCell GetTableCell(HyperLink link)
    {
        TableCell tc = new TableCell();
        tc.Controls.Add(link);
    
        return tc;
    }
