                var worksheet = package.Workbook.Worksheets[2];
                var value = worksheet.Cells["E42"].GetValue<DateTime>(); //the cell contains 32:20 in excel
                //returns 31.12.1899 08:20:00
                var value2 = worksheet.Cells["E39"].GetValue<DateTime>(); //the cell contains 00:00 in excel
                // which returns 30.12.1899 00:00:00
                var t = value.Subtract(value2); //returns 1.08:20:00, which translates to 32:20:00
