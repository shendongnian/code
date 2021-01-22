            string file = @"C:\sample.xlsx";
            if(System.IO.File.Exists(file))
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true; //FOR TESTING ONLY
                Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Open(file,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing,
                                    Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[1];   //Selects the first sheet
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 1];      //Select cell A1
                object cellValue = range.Value2;
                #region Extract the image
                Microsoft.Office.Interop.Excel.Picture pic = (Microsoft.Office.Interop.Excel.Picture)ws.Pictures(1);
                if (pic != null)
                {
                    //This code will detect what the region span of the image was
                    int startCol = (int)pic.TopLeftCell.Column;
                    int startRow = (int)pic.TopLeftCell.Row;
                    int endCol = (int)pic.BottomRightCell.Column;
                    int endRow = (int)pic.BottomRightCell.Row;
                    pic.CopyPicture(Microsoft.Office.Interop.Excel.XlPictureAppearance.xlScreen, Microsoft.Office.Interop.Excel.XlCopyPictureFormat.xlBitmap);
                    if (Clipboard.ContainsImage())
                    {
                        Image img = Clipboard.GetImage();
                        this.pictureBox1.Image = img;
                    }
                }
                #endregion
                //Close the workbook
                wb.Close(false,Type.Missing,Type.Missing);
                //Exit Excel
                excelApp.Quit();
            }
