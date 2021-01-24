           InsertDimensionRequest insertRow = new InsertDimensionRequest();
                insertRow.Range = new DimensionRange()
                {
                    SheetId = MySheetID,
                    Dimension = "ROWS",
                    StartIndex = 1,
                    EndIndex = 2
                };
                PasteDataRequest data = new PasteDataRequest
                {
                    Data = string.Join(",", values[0]),
                    Delimiter = ",",
                    Coordinate = new GridCoordinate
                    {
                        ColumnIndex = 0,
                        RowIndex = 1,
                        SheetId = MySheetID
                    },
                };
                BatchUpdateSpreadsheetRequest r = new BatchUpdateSpreadsheetRequest()
                {
                    Requests = new List<Request>
                    {
                        new Request{ InsertDimension = insertRow },
                        new Request{ PasteData = data }
                    }
                };
                BatchUpdateSpreadsheetResponse response1 = service.Spreadsheets.BatchUpdate(r, spreadsheetId).Execute();
