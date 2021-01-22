    /// <summary>
        /// Close open PowerPoint document
        /// </summary>
        /// <param name="path">Path to document</param>
        /// <param name="saveChanges">Save changes to document</param>
        public void PowerPointCloseOpenDocument(String path, Boolean saveChanges = true)
        {
            ppApp = getPowerPointApp(path);
            PowerPoint.Presentation pp = null;
            if (!String.IsNullOrEmpty(path))
            {
                foreach (PowerPoint.Presentation p in ppApp.Presentations)
                {
                    if (p.FullName.Equals(path, StringComparison.CurrentCultureIgnoreCase))
                    {
                        try
                        {
                            pp = p;
                        }
                        catch (Exception)
                        { }
                        break;
                    }
                }
            }
            if(saveChanges)
            {
                if(pp!=null)
                {
                    pp.Save();
                }
            }
            if(pp!= null)
            {
                Marshal.FinalReleaseComObject(pp);
            }
            if(null != ppApp)
            {
                Marshal.FinalReleaseComObject(ppApp);
            }
            var procs = FileUtil.WhoIsLocking(path);
            if(procs!= null)
            {
                foreach(var proc in procs)
                {
                    proc.Kill();
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    private PowerPoint.Application getPowerPointApp(String path = "")
        {
            try
            {
                PowerPoint.Application ppapp = null;
                try
                {
                    if (!String.IsNullOrEmpty(path))
                    {
                        ppapp = ((PowerPoint.Presentation)System.Runtime.InteropServices.Marshal.BindToMoniker(path)).Application;
                    }
                }
                catch (Exception) { }
                if (ppapp == null)
                {
                    try
                    {
                        ppapp = (PowerPoint.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("PowerPoint.Application");
                    }
                    catch (Exception)
                    {
                        ppapp = new PowerPoint.Application();
                        ppapp.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                    }
                }
                if (ppapp != null)
                {
                    ppapp.DisplayAlerts = Microsoft.Office.Interop.PowerPoint.PpAlertLevel.ppAlertsNone;
                }
                try { ppapp.Activate(); }
                catch (Exception) { }
                return ppapp;
            }
            catch (Exception)
            {
                return (PowerPoint.Application)Activator.CreateInstance(Type.GetTypeFromProgID("PowerPoint.Application"));
            }
        }
