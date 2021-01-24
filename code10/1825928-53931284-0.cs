                using SpreadsheetLight;
                SLDocument sl = new SLDocument();
                int iStartRowIndex = 1;
                int iStartColumnIndex = 1;
                
                sl.ImportDataTable(iStartRowIndex, iStartColumnIndex, dt, true);
                
                // + 1 because the header row is included
                // - 1 because it's a counting thing, because the start row is counted.
                int iEndRowIndex = iStartRowIndex + dt.Rows.Count + 1 - 1;
                // - 1 because it's a counting thing, because the start column is counted.
                int iEndColumnIndex = iStartColumnIndex + dt.Columns.Count - 1;
                SLTable table = sl.CreateTable(iStartRowIndex, iStartColumnIndex, iEndRowIndex, iEndColumnIndex);
                table.SetTableStyle(SLTableStyleTypeValues.Medium17);
                table.HasTotalRow = true;
                table.SetTotalRowFunction(5, SLTotalsRowFunctionValues.Sum);
                sl.InsertTable(table);
                sl.SaveAs(FilePath);
                sl.Dispose();
                ProcessStartInfo startInfo = new ProcessStartInfo(FilePath);
                Process.Start(startInfo);
