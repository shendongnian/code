        private bool WIAScannerTest() 
        {
                try
                {
                    WIA.CommonDialog wiaObj = New WIA.CommonDialog(); 
                    WIA.Device wiaDev = wiaObj.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, false, false);
                    
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
            
                    return true;
                }
                catch (Exception ex)
                {}
        
                return false;
        }
