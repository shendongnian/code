    using OfficeOpenXml;
    
    public class XmlService
    {
        // [...]
        public void getXlsxFile(SomeTableObject tbl, ref byte[] bytes)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(tbl.name);
                ws.Cells["A1"].LoadFromDataTable(tbl, true);
                bytes = pck.GetAsByteArray();
            }
        }
    }
