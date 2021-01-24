    using OfficeOpenXml;
    
    namespace MyProject.Controllers
    {
        public class SubscribersController : Controller
        {
            private readonly ApplicationDbContext _context;
    
            public SubscribersController(ApplicationDbContext context)
            {
                _context = context;
            }
    
            public async Task<IActionResult> ExportToExcel()
            {
                var stream = new System.IO.MemoryStream();
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    var subscribers = await _context.Subscribers.ToListAsync();                        
    
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Subscribers");
    
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Email";
                    worksheet.Cells[1, 3].Value = "Date Subscribed";
                    worksheet.Row(1).Style.Font.Bold = true;
    
                    for (int c = 2; c < subscribers.Count + 2; c++)
                    {
                        worksheet.Cells[c, 1].Value = subscribers[c - 2].Name;
                        worksheet.Cells[c, 2].Value = subscribers[c - 2].Email;
                        worksheet.Cells[c, 3].Value = subscribers[c - 2].DateCreated.ToString();
                    }
    
                    package.Save();
                }
    
                string fileName = @"Subscribers.xlsx";
                string fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                stream.Position = 0;
                return File(stream, fileType, fileName);
            }
        }
    }
    
