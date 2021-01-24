     private void insertDataToSheet(string path, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            Workbook g_Workbook = excelApp.Workbooks.Open(
                path,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            bool gotData = false;
            object misValue = System.Reflection.Missing.Value;
            //load different data list to datagridview but changing the comboBox selected index
            for (int i = 0; i <= cmbType.Items.Count - 1; i++)
            {
                cmbType.SelectedIndex = i;
                for (int j = 0; j <= cmbSubType.Items.Count - 1; j++)
                {
                    cmbSubType.SelectedIndex = j;
                    if (cmbType.Text.Equals(CMBPartHeader))
                    {
                        gotData = loadPartStockData();//if data != empty return true, else false
                    }
                    else if (cmbType.Text.Equals(CMBMaterialHeader))
                    {
                        gotData = loadMaterialStockData();//if data != empty return true, else false
                    }
                    if (gotData)//if datagridview have data
                    {
                        Worksheet addedSheet = null;
                        int count = g_Workbook.Worksheets.Count;
                        addedSheet = g_Workbook.Worksheets.Add(Type.Missing,
                                g_Workbook.Worksheets[count], Type.Missing, Type.Missing);
     
                        addedSheet.Name = cmbSubType.Text;
                        addedSheet.PageSetup.LeftHeader = "&\"Calibri,Bold\"&11 " + DateTime.Now.Date.ToString("dd/MM/yyyy"); ;
                        addedSheet.PageSetup.CenterHeader = "&\"Calibri,Bold\"&16 (" + cmbSubType.Text + ") STOCK LIST";
                        addedSheet.PageSetup.RightHeader = "&\"Calibri,Bold\"&11 PG -&P";
                        addedSheet.PageSetup.CenterFooter = "Printed By " + dalUser.getUsername(MainDashboard.USER_ID);
                        //Page setup
                        addedSheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                        addedSheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                        addedSheet.PageSetup.Zoom = false;
                        addedSheet.PageSetup.CenterHorizontally = true;
                        addedSheet.PageSetup.LeftMargin = 1;
                        addedSheet.PageSetup.RightMargin = 1;
                        addedSheet.PageSetup.FitToPagesWide = 1;
                        addedSheet.PageSetup.FitToPagesTall = false;
                        addedSheet.PageSetup.PrintTitleRows = "$1:$1";
                        copyAlltoClipboard();
                        addedSheet.Select();
                        Range CR = (Range)addedSheet.Cells[1, 1];
                        CR.Select();
                        addedSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                        Range tRange = addedSheet.UsedRange;
                        tRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = XlBorderWeight.xlThin;
                        tRange.Font.Size = 11;
                        tRange.EntireColumn.AutoFit();
                        tRange.Rows[1].interior.color = Color.FromArgb(237, 237, 237);//change first row back color to light grey
                        Clipboard.Clear();
                        dgvStockReport.ClearSelection();
                    }
                }
            }
            g_Workbook.Worksheets.Item[1].Delete();
            g_Workbook.Save();
        }
