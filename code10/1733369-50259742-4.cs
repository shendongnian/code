    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    namespace DL.SO.Web.UI.Controllers
    {
        public class ExcelController : Controller
        {
            public IActionResult Download()
            {
                byte[] fileContents;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    // Put whatever you want here in the sheet
                    // For example, for cell on row1 col1
                    worksheet.Cells[1, 1].Value = "Long text";
                    worksheet.Cells[1, 1].Style.Font.Size = 12;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                    // So many things you can try but you got the idea.
                    // Finally when you're done, export it to byte array.
                    fileContents = package.GetAsByteArray();
                }
                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "test.xlsx"
                );
            }
        }
    }
