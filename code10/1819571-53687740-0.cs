    private static void PutInExcel(List<RulesEngineOutput> output)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(@"C:\ATP\Sprints\PA\RE\IO.xlsx", true))
            {
                // Add a blank WorksheetPart.
                WorksheetPart newWorksheetPart = document.WorkbookPart.AddNewPart<WorksheetPart>();
                newWorksheetPart.Worksheet = new Worksheet(); // Change 1
                Sheets sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                string relationshipId = document.WorkbookPart.GetIdOfPart(newWorksheetPart);
                // Get a unique ID for the new worksheet.
                uint sheetId = 1;
                if (sheets.Elements<Sheet>().Count() > 0)
                {
                    sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }
                // Give the new worksheet a name.
                string sheetName = "NewRole" + sheetId;
                // Append the new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = sheetName };
                sheets.Append(sheet);
                SheetData sheetData = newWorksheetPart.Worksheet.AppendChild(new SheetData());
                // Constructing header
                Row row = new Row();
                row.Append(
                    ConstructCell("Code", CellValues.String), // Change 2
                    ConstructCell("Description", CellValues.String));
                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
                foreach (var reItem in output)
                {
                    row = new Row();
                    row.Append(
                        ConstructCell(reItem.Code.ToString(), **CellValues.String**),
                        ConstructCell(reItem.Description, CellValues.String)
                        );
                    sheetData.AppendChild(row);
                }
                newWorksheetPart.Worksheet.Save();
                document.WorkbookPart.Workbook.Save();
                document.Save();
            }
            //string csv = String.Join(",", output.Select(x => x.ToString()).ToArray());
        }
