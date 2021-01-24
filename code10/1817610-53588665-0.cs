    Workbook wb = new Workbook();
    Worksheet sheet = wb.Worksheets[0];
    
     
    sheet.Range["A1"].Text = "Align Picture Within A Cell:";
    sheet.Range["A1"].Style.VerticalAlignment = VerticalAlignType.Top;
    
     
    string picPath = @"C:\Users\Administrator\Desktop\scenery.jpg";
    ExcelPicture picture = sheet.Pictures.Add(1, 1, picPath);
    
    sheet.Columns[0].ColumnWidth = 50;
    sheet.Rows[0].RowHeight = 150;
    
    picture.LeftColumnOffset =100;
    picture.TopRowOffset = 25;
    
    
    wb.SaveToFile("AlignPicture.xlsx", ExcelVersion.Version2013);
