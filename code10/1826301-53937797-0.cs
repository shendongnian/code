    using (SpreadsheetDocument document = SpreadsheetDocument.Open(INPUT_DIRECTORY, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                foreach (Sheet sheet in wbPart.Workbook.Sheets)
                {
                    switch (sheet.Name.ToString())
                    {
                        case "ABC":
                            WorksheetPart wsPart = (WorksheetPart)wbPart.GetPartById(sheet.Id);
                            SheetData sheetdata = wsPart.Worksheet.Elements<SheetData>().FirstOrDefault();                            
                            foreach (Row r in sheetdata.Elements<Row>())
                            {
                                string xxx = r.Elements<Cell>().ElementAt(0).InlineString.Text.Text;
                                string yyy = r.Elements<Cell>().ElementAt(6).InlineString.Text.Text;
                                string zzz = r.Elements<Cell>().ElementAt(12).InlineString.Text.Text;
                            }                            
                            break;
                    }
                }
            }
