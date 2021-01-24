    for (int col = 1; col <= ws.Dimension.End.Column; col++)
    {
        ws.Column(col).Width = ws.Column(col).Width + 1;
    
        for (var j = 1; j <= ws.Dimension.End.Row; j++)
        {
            ws.Cells[col, j].Hyperlink = new ExcelHyperLink(Uri.EscapeUriString("http://www.google.nl".Replace("[", "%5B").Replace("]", "%5D"))) { Display = "Link" };
        }
    }
