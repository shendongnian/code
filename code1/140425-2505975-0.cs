        public void DisposeExcelInstance()
        {
            //oXL.DisplayAlerts = false;
            //oWB.Close(null, null, null);
            //oXL.Quit();
            
            //oWB.Close(null, null, null);
            //oXL.Quit();
            ///KNG - CLEANUP code
            oXL.DisplayAlerts = false;
            oWB.Close(null, null, null);
            oXL.Workbooks.Close();
            oXL.Quit();
            if (oResizeRange != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oResizeRange);
            if (oSheet != null) 
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            if (oWB != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
            if (oXL != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            oSheet = null;
            oWB = null;
            oXL = null;
            GC.Collect(); // force final cleanup!
        }
