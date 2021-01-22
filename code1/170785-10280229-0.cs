    PowerPoint.Application powerPoint = new Microsoft.Office.Interop.PowerPoint.Application();
        //powerPoint.Visible = Office.MsoTriState.msoTrue;
        Microsoft.Office.Interop.PowerPoint.Presentation ppt = null;
        
        try
        {
            ppt = powerPoint.Presentations.Open(localCopyOfPPT,  
                                                Microsoft.Office.Core.MsoTriState.msoCTrue,
                                                Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
                                                Microsoft.Office.Core.MsoTriState.msoFalse);
         ppt.Close();
         Marshal.FinalReleaseComObject(ppt);
         }catch(){}finally
        {  
            powerPoint.Quit();
            Marshal.FinalReleaseComObject(powerPoint);
            GC.Collect();
        }
