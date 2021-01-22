    using word = Microsoft.Office.Interop.Word;    
    public static void ExportToWord(DataGridView dgv)
                    {
                        SendMessage("Opening Word");
            
                        word.ApplicationClass word = null;
    
          
          word.Document doc = null;
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */ 
                try
                {
                    word = new word.ApplicationClass();
                    word.Visible = true;
                    doc = word.Documents.Add(ref oMissing, ref oMissing,ref oMissing, ref oMissing);
                }
                catch (Exception ex)
                {
                    ErrorLog(ex);
                }
                finally
                {
                }
                if (word != null && doc != null)
                {
                    word.Table newTable;
                    word.Range wrdRng = doc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    newTable = doc.Tables.Add(wrdRng, 1, dgv.Columns.Count-1, ref oMissing, ref oMissing);
                    newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    newTable.AllowAutoFit = true;
    
                    foreach (DataGridViewCell cell in dgv.Rows[0].Cells)
                    {
                        newTable.Cell(newTable.Rows.Count, cell.ColumnIndex).Range.Text = dgv.Columns[cell.ColumnIndex].Name;
              
                    }
                    newTable.Rows.Add();
    
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            newTable.Cell(newTable.Rows.Count, cell.ColumnIndex).Range.Text = cell.Value.ToString();                      
                        }
                        newTable.Rows.Add();
                    }                                              
                }
    
            }
