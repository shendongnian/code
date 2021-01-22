            Worksheet workSheet = (Worksheet)newWorkbook.Sheets.Add
                    (
                        existingWorksheet, // before
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, // 1,
                        System.Reflection.Missing.Value //XlSheetType.xlWorksheet
                    );
