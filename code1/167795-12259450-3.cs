    // Bulk Transfer
    String MaxRow = (alllogentry.Rows.Count+6).ToString();
     String MaxColumn = ((String)(Convert.ToChar(alllogentry.Columns.Count / 26 + 64).ToString() + Convert.ToChar(alllogentry.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
    String MaxCell = MaxColumn + MaxRow;
                    
    //Format
    worksheet.get_Range("A1", MaxColumn + "1").Font.Bold = true;
    worksheet.get_Range("A1", MaxColumn + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;
    
    // Insert Statement
        worksheet.get_Range("A7", MaxCell).Value2 = Values;
