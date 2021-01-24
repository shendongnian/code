        //open file into p
    using (var p = new OfficeOpenXml.ExcelPackage(new FileInfo(@"c:\FooFolder\Foo.xlsx")))
    {
    ExcelWorkbook wb = p.Workbook;
    ExcelWorksheet ew = wb.Worksheets.First();
    //create a dictionary to store your cell colors
    Dictionary<string, Color> cellColors = new Dictionary<string, Color>();
                
    //define your rows and columns to loop through
    int rowNum = ew.Dimension.Start.Row;
    int rowEnd = ew.Dimension.End.Row;
    int cellBegin = ew.Dimension.Start.Column;
    int cellEnd = ew.Dimension.End.Column;
    //loop through all of the rows
    for (int y = rowNum; y<= rowEnd; y++)
    {
        //loop through the cells in each row
        for(int x= cellBegin; x<= cellEnd; x++)
        {
            //get the range of the current cll
            ExcelRange currentCell = ew.Cells[y, x];
            //get the rgb string value of the background color 
            string rgb = ew.Cells[y,x].Style.Fill.BackgroundColor.Rgb;
            //create variable to convert rgb color to C# color
            System.Drawing.Color CurrentCellColor;
                        
            //if rgb is null then there is no background color so default to white.
            if (rgb != null)
                CurrentCellColor = System.Drawing.ColorTranslator.FromHtml("#" + rgb);
            else
                CurrentCellColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            //add to your dictionary if is yellow
            if (rgb != null && CurrentCellColor.Equals(Color.Yellow))
                cellColors.Add(currentCell.Address, CurrentCellColor);
        }
    }
    p.Save();
    }
