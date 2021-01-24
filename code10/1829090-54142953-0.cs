    [Transaction(TransactionMode.Manual)]
    internal class DataInput : IExternalCommand
    {
        private static WindowHandle _hWndRevit = null;
    
        private void SetHandle()
        {
            if (null == _hWndRevit)
            {
                Process process
                  = Process.GetCurrentProcess();
    
                IntPtr h = process.MainWindowHandle;
                _hWndRevit = new WindowHandle(h);
            }
        }
    
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
    
            SetHandle();
    
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
    
            // Form instanziieren
            var dataInputForm = new DataInputForm(uidoc);
            // Form starten
            if (_hWndRevit != null)
            {
                dataInputForm.Show(_hWndRevit);
            }
            else
            {
                return Result.Failed;
            }
    
            return Result.Succeeded;
        }
    }
