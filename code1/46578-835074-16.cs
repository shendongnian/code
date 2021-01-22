    AtomLink cellFeedLink = worksheetentry.Links.FindService(GDataSpreadsheetsNameTable.CellRel, null);
    
    CellQuery query = new CellQuery(cellFeedLink.HRef.ToString());
    CellFeed feed = service.Query(query);
    
    Console.WriteLine("Cells in this worksheet:");
    foreach (CellEntry curCell in feed.Entries)
    {
        Console.WriteLine("Row {0}, column {1}: {2}", curCell.Cell.Row,
            curCell.Cell.Column, curCell.Cell.Value);
    }
