    using OfficeOpenXml;  // namespace for the ExcelPackage assembly
 
    FileInfo newFile = new FileInfo(@"C:\mynewfile.xlsx"); 
    using (ExcelPackage xlPackage = new ExcelPackage(newFile)) 
    {
       ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Tinned Goods");
       // write some titles into column 1
       worksheet.Cell(1, 1).Value = "Product";
   
       worksheet.Cell(4, 1).Value = "Peas";
       worksheet.Cell(5, 1).Value = "Total";
       // write some values into column 2
       worksheet.Cell(1, 2).Value = "Tins Sold";
   
       ExcelCell cell = worksheet.Cell(2, 2);
       cell.Value = "15"; // tins of Beans sold
       string calcStartAddress = cell.CellAddress;  // we want this for the formula
       worksheet.Cell(3, 2).Value = "32";  // tins Carrots sold
       worksheet.Cell(5, 2).Formula = string.Format("SUM({0}:{1})",
       calcStartAddress, calcEndAddress);
    }
