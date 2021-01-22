            using Excel = Microsoft.Office.Interop.Excel;
            Excel.ApplicationClass _Excel;
            Excel.Workbook WB;
            Excel.Worksheet WS;
            _Excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            WB = _Excel.Workbooks.Add(System.Reflection.Missing.Value);
      
            WS = (Excel.Worksheet)WB.Worksheets[1]; 
            WS.Name = "Test";
       
             try
            {
                
                int row;
                int col;
                WS.Cells[++row, col] = "COL1";
                WS.Cells[row, ++col] = "COL2";
               
                WS.get_Range("A1", "A2").Font.Bold = true;
                WS.get_Range("A1", "A2").HorizontalAlignment                     =Excel.XlHAlign.xlHAlignCenter;
                WS.Cells[++row, col] = "Customer";
                WS.Cells[++row, col] = "Expenses" 
                WS.get_Range("A1", "B1").Font.Bold = true;
                    
                WS.Columns.AutoFit();
                WS.Rows.AutoFit();
                WS.Activate();
               _Excel.Visible = true;
            }
            catch (Exception ex)
            {
                WB.Close(false, Type.Missing, Type.Missing);
                _Excel.Quit();
                throw;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WS);
             
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WB);
                
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_Excel);
            }
