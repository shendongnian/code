    private bool WIAScannerTest() 
    {
           try
           {
               WIA.CommonDialog wiaObj = New WIA.CommonDialog(); 
               WIA.Device wiaDev = 
                      wiaObj.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, false, false);
               return true;
           }
           catch (Exception ex)
           {}
           finally
           {
               if(wiaDev != null)
               {
                   Marshal.ReleaseComObject(wiaDev)
                   wiaDev = null;
               }
               if(wiaObj != null)
               {
                  Marshal.ReleaseComObject(wiaObj)
                  wiaObj = null;
               }
           }
           return false;
    }
