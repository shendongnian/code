         public bool chec()
                {
                    Excel.Application oExcelApp;
        
        
                    try
                    {
        
                        oExcelApp = (Excel.
    
    Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application"); ;
                    if (oExcelApp.ActiveWorkbook != null)
                    {
                        Excel.Workbook xlwkbook = (Excel.Workbook)oExcelApp.ActiveWorkbook;
    
                        
                        ke k = new ke(ref oExcelApp, ref xlwkbook);
    
                    }
                   
    
                }
                catch 
                {
                    if (reg > 100) { } else { reg++; goto End; }//public static int reg=0;
                    oExcelApp = null;
                    
                    /*Process[] ppo = Process.GetProcessesByName("EXCEL");
                    foreach(Process pppp in ppo)
                    {
                      pppp.Kill();
                    }*/
                    
                    End:
                    return false;
                    
                }
               
                   finally{ oExcelApp = null;
                    System.GC.Collect();}
                   
               
    
    
                return true;
            }
        }
