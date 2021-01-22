    public void excelRead(string sheetName)
            {
                Excel.Application appExl = new Excel.Application();
                Excel.Workbook workbook = null;
                try
                {
                    string methodName = "";
    
    
                    Excel.Worksheet NwSheet;
                    Excel.Range ShtRange;
    
                    //Opening Excel file(myData.xlsx)
                    appExl = new Excel.Application();
    
    
                    workbook = appExl.Workbooks.Open(sheetName, Missing.Value, ReadOnly: false);
                    NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                    ShtRange = NwSheet.UsedRange; //gives the used cells in sheet
    
    
                    int rCnt1 = 0;
                    int cCnt1 = 0;
    
                    for (rCnt1 = 1; rCnt1 <= ShtRange.Rows.Count; rCnt1++)
                    {
                        for (cCnt1 = 1; cCnt1 <= ShtRange.Columns.Count; cCnt1++)
                        {
                            if (Convert.ToString(NwSheet.Cells[rCnt1, cCnt1].Value2) == "Y")
                            {
    
                                methodName = NwSheet.Cells[rCnt1, cCnt1 - 2].Value2;
                                Type metdType = this.GetType();
                                MethodInfo mthInfo = metdType.GetMethod(methodName);
    
                                if (Convert.ToString(NwSheet.Cells[rCnt1, cCnt1 - 2].Value2) == "fn_AddNum" || Convert.ToString(NwSheet.Cells[rCnt1, cCnt1 - 2].Value2) == "fn_SubNum")
                                {
                                    StaticVariable.intParam1 = Convert.ToInt32(NwSheet.Cells[rCnt1, cCnt1 + 3].Value2);
                                    StaticVariable.intParam2 = Convert.ToInt32(NwSheet.Cells[rCnt1, cCnt1 + 4].Value2);
                                    object[] mParam1 = new object[] { StaticVariable.intParam1, StaticVariable.intParam2 };
                                    object result = mthInfo.Invoke(this, mParam1);
                                    StaticVariable.intOutParam1 = Convert.ToInt32(result);
                                    NwSheet.Cells[rCnt1, cCnt1 + 5].Value2 = Convert.ToString(StaticVariable.intOutParam1) != "" ? Convert.ToString(StaticVariable.intOutParam1) : String.Empty;
                                }
    
                                else
                                {
                                    object[] mParam = new object[] { };
                                    mthInfo.Invoke(this, mParam);
    
                                    NwSheet.Cells[rCnt1, cCnt1 + 5].Value2 = StaticVariable.outParam1 != "" ? StaticVariable.outParam1 : String.Empty;
                                    NwSheet.Cells[rCnt1, cCnt1 + 6].Value2 = StaticVariable.outParam2 != "" ? StaticVariable.outParam2 : String.Empty;
                                }
                                NwSheet.Cells[rCnt1, cCnt1 + 1].Value2 = StaticVariable.resultOut;
                                NwSheet.Cells[rCnt1, cCnt1 + 2].Value2 = StaticVariable.resultDescription;
                            }
    
                            else if (Convert.ToString(NwSheet.Cells[rCnt1, cCnt1].Value2) == "N")
                            {
                                MessageBox.Show("Result is No");
                            }
                            else if (Convert.ToString(NwSheet.Cells[rCnt1, cCnt1].Value2) == "EOF")
                            {
                                MessageBox.Show("End of File");
                            }
    
                        }
                    }
    
                    workbook.Save();
                    workbook.Close(true, Missing.Value, Missing.Value);
                    appExl.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ShtRange);
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(NwSheet);
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(appExl);
                }
                catch (Exception)
                {
                    workbook.Close(true, Missing.Value, Missing.Value);
                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    System.Runtime.InteropServices.Marshal.CleanupUnusedObjectsInCurrentContext();
                }
            }
    
    //code for reading excel data in datatable
    public void testExcel(string sheetName)
            {
                try
                {
                    MessageBox.Show(sheetName);
    
                    foreach(Process p in Process.GetProcessesByName("EXCEL"))
                    {
                        p.Kill();
                    }
                    //string fileName = "E:\\inputSheet";
                    Excel.Application oXL;
                    Workbook oWB;
                    Worksheet oSheet;
                    Range oRng;
    
    
                    //  creat a Application object
                    oXL = new Excel.Application();
    
    
    
    
                    //   get   WorkBook  object
                    oWB = oXL.Workbooks.Open(sheetName);
    
    
                    //   get   WorkSheet object
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[1];
                    System.Data.DataTable dt = new System.Data.DataTable();
                    //DataSet ds = new DataSet();
                    //ds.Tables.Add(dt);
                    DataRow dr;
    
    
                    StringBuilder sb = new StringBuilder();
                    int jValue = oSheet.UsedRange.Cells.Columns.Count;
                    int iValue = oSheet.UsedRange.Cells.Rows.Count;
    
    
                    //  get data columns
                    for (int j = 1; j <= jValue; j++)
                    {
                        oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, j];
                        string strValue = oRng.Text.ToString();
                        dt.Columns.Add(strValue, System.Type.GetType("System.String"));
                    }
    
    
                    //string colString = sb.ToString().Trim();
                    //string[] colArray = colString.Split(':');
    
    
                    //  get data in cell
                    for (int i = 2; i <= iValue; i++)
                    {
                        dr = dt.NewRow();
                        for (int j = 1; j <= jValue; j++)
                        {
                            oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                            string strValue = oRng.Text.ToString();
                            dr[j - 1] = strValue;
    
    
                        }
                        dt.Rows.Add(dr);
                    }
                    if(StaticVariable.dtExcel != null)
                    {
                        StaticVariable.dtExcel.Clear();
                        StaticVariable.dtExcel = dt.Copy();
                    }
                    else
                    StaticVariable.dtExcel = dt.Copy();
    
                    oWB.Close(true, Missing.Value, Missing.Value);
                    oXL.Quit();
                    MessageBox.Show(sheetName);
    
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
    
                }
            }
    
    //code for class initialize
     public static void startTesting(TestContext context)
            {
                
                Playback.Initialize();
                ReadExcel myClassObj = new ReadExcel();
                string sheetName="";
                StreamReader sr = new StreamReader(@"E:\SaveSheetName.txt");
                sheetName = sr.ReadLine();
                sr.Close();
    			myClassObj.excelRead(sheetName);
                myClassObj.testExcel(sheetName);
            }
    
    //code for test initalize
    public  void runValidatonTest()
            {
                
                DataTable dtFinal = StaticVariable.dtExcel.Copy();
                for (int i = 0; i < dtFinal.Rows.Count; i++)
                {
                    if (TestContext.TestName == dtFinal.Rows[i][2].ToString() && dtFinal.Rows[i][3].ToString() == "Y" && dtFinal.Rows[i][4].ToString() == "TRUE")
                    {
                        MessageBox.Show(TestContext.TestName);
                        MessageBox.Show(dtFinal.Rows[i][2].ToString());
                        StaticVariable.runValidateResult = "true";
                        break;
                    }
                }
                //StaticVariable.dtExcel = dtFinal.Copy();
            }
