    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(filepath);
                    var sheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
                    var range = sheet.Range["A1"];
                    range.Value2 = "some value";
