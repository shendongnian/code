    class FileHelper
    {
        public static string saveLocation;
        public static SpreadsheetDocument spreadsheetDoc;
        public static async Task GetFileAsync()
        {
            var (authResult, message) = await Authentication.AquireTokenAsync();
            var httpClient = new HttpClient();
            HttpResponseMessage response;
            var request = new HttpRequestMessage(HttpMethod.Get, MainPage.fileurl);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            response = await httpClient.SendAsync(request);
            byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
            StorageLibrary videoLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
            string saveFolder = videoLibrary.SaveFolder.Path;
            string saveFileName = App.Date + "-" + App.StartTime + "-" + App.IBX + "-" + App.Generator + ".xlsx";
            saveLocation = saveFolder + "\\" + saveFileName;
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(fileBytes, 0, (int)fileBytes.Length);
                using (spreadsheetDoc = SpreadsheetDocument.Open(stream, true))
                {
                    await Task.Run(() =>
                    {
                        File.WriteAllBytes(saveLocation, stream.ToArray());
                        return TaskStatus.RanToCompletion;
                    });                    
                }
            }           
        }
        public async static Task UpdateCell(string docName, string text,
            uint rowIndex, string columnName)
        {
            StorageLibrary videoLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
            string saveFolder = videoLibrary.SaveFolder.Path;
            string saveFileName = App.Date + "-" + App.StartTime + "-" + App.IBX + "-" + App.Generator + ".xlsx";
            saveLocation = saveFolder + "\\" + saveFileName;
            await Task.Run(() =>
            {
                using (spreadsheetDoc = SpreadsheetDocument.Open(saveLocation, true))
                {
                    WorksheetPart worksheetPart =
                        GetWorksheetPartByName(spreadsheetDoc, "GenRun");
                    if (worksheetPart != null)
                    {
                        Cell cell = GetCell(worksheetPart.Worksheet,
                                                    columnName, rowIndex);
                        cell.CellValue = new CellValue(text);
                        cell.DataType =
                            new EnumValue<CellValues>(CellValues.String);
                        worksheetPart.Worksheet.Save();
                    }
                }
                return TaskStatus.RanToCompletion;
            });                              
        }
        private static WorksheetPart
             GetWorksheetPartByName(SpreadsheetDocument document,
             string sheetName)
        {
            IEnumerable<Sheet> sheets =
               document.WorkbookPart.Workbook.GetFirstChild<Sheets>().
               Elements<Sheet>().Where(s => s.Name == sheetName);
            if (sheets.Count() == 0)
            {
                return null;
            }
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)
                 document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }
        private static Cell GetCell(Worksheet worksheet,
                  string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);
            if (row == null)
                return null;
            return row.Elements<Cell>().Where(c => string.Compare
                   (c.CellReference.Value, columnName +
                   rowIndex, true) == 0).First();
        }
        private static Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().
              Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
    }
