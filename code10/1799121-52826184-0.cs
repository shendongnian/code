    int i = 1;
    var doc = new Document();
    var builder = new DocumentBuilder(doc);
    
    Table tab = builder.StartTable();
    
    builder.RowFormat.Borders.Horizontal.LineStyle = LineStyle.Dot;
    
    InsertCellAuto();
    InsertCell("merge 1");
    builder.CellFormat.VerticalMerge = CellMerge.First;
    builder.EndRow();
    
    builder.CellFormat.VerticalMerge = CellMerge.None; //reset
    
    InsertCellAuto();
    InsertCellAuto();
    builder.CellFormat.VerticalMerge = CellMerge.Previous;
    builder.EndRow();
    
    builder.CellFormat.VerticalMerge = CellMerge.None; //reset
    
    InsertCellAuto();
    InsertCell("merge 2");
    builder.CellFormat.VerticalMerge = CellMerge.First;
    builder.EndRow();
    
    builder.CellFormat.VerticalMerge = CellMerge.None; //reset
    
    InsertCellAuto();
    InsertCellAuto();
    builder.CellFormat.VerticalMerge = CellMerge.Previous;
    builder.EndRow();
    
    builder.EndTable();
    
    Row row = tab.Rows[1];
    foreach (Cell cell in row.Cells)
    {
        cell.CellFormat.Borders[BorderType.Bottom].LineStyle = LineStyle.Single;
    }
    
    doc.Save("D:\\temp\\18.10.docx");
    
    void InsertCellAuto() => InsertCell(i++.ToString());
    
    void InsertCell(string text)
    {
        builder.InsertCell();
        builder.Writeln(text);
    }
