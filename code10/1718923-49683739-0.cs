    using Excelx = Microsoft.Office.Interop.Excel;
    Excelx.Workbook wb = xlApp.ActiveWorkbook;
    object links = wb.LinkSources(Excelx.XlLink.xlExcelLinks);
    Array linkz = (Array)links;
    for (int i = 1; i <= linkz.Length; i++)
    {
        wb.UpdateLink(linkz.GetValue(i).ToString(), Excelx.XlLinkType.xlLinkTypeExcelLinks);
    }
