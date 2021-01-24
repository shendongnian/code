    public void Export()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                var headerRow = new List<string[]>()
                {
                    new string[] { "Id", "FirstName", "LastName",  }
                };
                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                worksheet.DefaultColWidth = 20.0;
                var counter = 2;
                foreach (Attendee item in context.Attendees.Include(attendee => attendee.Tags))
                {
                    int column = 1;
                    worksheet.Cells[counter, column++].Value = item.Id;
                    worksheet.Cells[counter, column++].Value = item.FirstName;
                    worksheet.Cells[counter++, column++].Value = item.LastName;
                }
                //Create the response
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.HeaderEncoding = Encoding.UTF8;
                Response.Charset = Encoding.UTF8.WebName;
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", "attachment; filename=people.xlsx");
                Response.BinaryWrite(excel.GetAsByteArray()); 
                Response.Flush(); 
                Response.End();
        }
    }
