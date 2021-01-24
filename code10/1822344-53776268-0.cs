    using (ExcelPackage package = new ExcelPackage(fi))
    {
        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
    
        //set the column start positions for both sexes
        int startMale = 1;
        int startFemale = 5;
    
        //first the males. start at row 2 to skip the header
        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
        {
            string FirstName = worksheet.Cells[row, startMale].Value.ToString();
            string LastName = worksheet.Cells[row, startMale + 1].Value.ToString();
            string Sex = worksheet.Cells[row, startMale + 2].Value.ToString();
            string Age = worksheet.Cells[row, startMale + 3].Value.ToString();
        }
    
        //then the females
        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
        {
            string FirstName = worksheet.Cells[row, startFemale].Value.ToString();
            string LastName = worksheet.Cells[row, startFemale + 1].Value.ToString();
            string Sex = worksheet.Cells[row, startFemale + 2].Value.ToString();
            string Age = worksheet.Cells[row, startFemale + 3].Value.ToString();
        }
    }
