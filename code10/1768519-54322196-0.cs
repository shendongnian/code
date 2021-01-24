    void OpenFiles()
    {
        foreach (string strFile in sourceFiles) //sourceFiles is a list containing the file paths
        {
            bool b = false;
            Excel.Workbook bookSource = app.Workbooks._Open(strFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Excel.Worksheet sheetSource = bookSource.Worksheets[1] as Excel.Worksheet;
            
            CopyData();
        }
        //finally save the file as your requirements and close all the open workbooks
    }
    void CopyData()
    {
        Excel.Worksheet lastsheet = null;   //last sheet in the workbook
        int limit = 1000000; //variable to check if your sheet has exceeded
        try
        {
            var sheets = bookDest.Sheets;
            lastsheet = (Excel.Worksheet)bookDest.Sheets[sheets.Count];
            hc.ReleaseObject(sheets);
            drc = lastsheet.UsedRange.Rows.Count;       //no of rows used in result workbook
            src = sheetSource.UsedRange.Rows.Count;     //no of rows used in source workbook
            //if else loop to check if you have exceeded 1st sheet limit before start copying
            if ((drc + src) <= limit)
            {
                int sheetRowCount = sheetSource.UsedRange.Rows.Count;
                Excel.Range range = sheetSource.get_Range(string.Format("A{0}", _headerRowCount), _columnEnd + sheetRowCount.ToString());
                range.Copy(lastsheet.get_Range(string.Format("A{0}", _currentRowCount), Missing.Value));
                _currentRowCount += range.Rows.Count;
            }
            else if ((drc >= limit && src >= limit) || drc >= limit || src >= limit || (drc + src) >= limit)
            {
                    Excel.Worksheet newSheet = (Excel.Worksheet)bookDest.Worksheets.Add(After: lastsheet);
                    newSheet.Name = "Result " + (cnt++);
                    hc.ReleaseObject(lastsheet);
                    lastsheet = newSheet;
                    lastsheet.Activate();
                    CopyHeader(lastsheet);
                    //((Excel.Worksheet) this.app.ActiveWorkbook.Sheets[lastsheet]).Select();
                    int sheetRowCount = sheetSource.UsedRange.Rows.Count;
                    Excel.Range range = sheetSource.get_Range(string.Format("A{0}", _headerRowCount), _columnEnd + sheetRowCount.ToString());
                    range.Copy(lastsheet.get_Range(string.Format("A{0}", _currentRowCount), Missing.Value));
                    _currentRowCount += range.Rows.Count;
                }
            }
            else
            {
                int sheetRowCount = sheetSource.UsedRange.Rows.Count;
                Excel.Range range = sheetSource.get_Range(string.Format("A{0}", _headerRowCount), _columnEnd + sheetRowCount.ToString());
                range.Copy(lastsheet.get_Range(string.Format("A{0}", _currentRowCount), Missing.Value));
                _currentRowCount += range.Rows.Count;
            }
        }
        catch (IndexOutOfRangeException)
        {
            MessageBox.Show("Some problem with the source file", "Copy error");
        }
        finally
        {
            ReleaseObject(lastsheet);
        }
    }
