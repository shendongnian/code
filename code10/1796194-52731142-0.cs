    using (var p = new OfficeOpenXml.ExcelPackage(new FileInfo(@"c:\FooFolder\Foo.xlsx")))
    {
        ExcelWorkbook wb = p.Workbook;
        ExcelWorksheet ws = wb.Worksheets[1];
        //create variable for previous range that will persist through each loop
        ExcelRange previousRange = null;
        //set position of first column to merge
        int mergecellBegin = 1;
        //set position of last column to merge
        int mergeCellEnd = 3;
        //create variable to check the cells of your rows
        bool areCellsEqual;
        //iterate through each row in the dataset
        for (var rowNum = 2; rowNum <= ws.Dimension.End.Row; rowNum++)
        {
            ExcelRange currentRange = ws.Cells[rowNum, 1, rowNum, mergeCellEnd];
            //will skip if we haven't set previous range yet
            if (previousRange != null)
            {
                //reset your check variable
                areCellsEqual = true;
                //check if all cells in the ranges are qual to eachother
                for (int i = 1; i <= mergeCellEnd; i++)
                {
                    //if the cells from the ranges are not equal then set check variable to false and break the loop
                    if (!currentRange[rowNum, i].Value.Equals(previousRange[rowNum - 1, i].Value))
                    {
                        areCellsEqual = false;
                        break;
                    }
                }
                //if all cells from the two ranges match, merge them together.
                if (areCellsEqual)
                {
                    //merge each cell in the ranges
                    for (int i = 1; i <= mergeCellEnd; i++)
                    {
                        ExcelRange mergeRange = ws.Cells[rowNum - 1, i, rowNum, i];
                        mergeRange.Merge = true;
                    }
                }
            }
            //sets the previous range to the current range to be used in next iteration
            previousRange = currentRange;
        }
        p.Save();
    }
