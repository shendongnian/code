            if (!isExcelInteractive())
            {
                // get the current range
                Excel.Range r = Globals.ThisAddIn.Application.ActiveCell;
                // bring Excel to the foreground, with focus
                // and issue keys to exit the cell
                xlBringToFront();
                Globals.ThisAddIn.Application.ActiveWindow.Activate();
                SendKeys.Flush();
                SendKeys.SendWait("{ENTER}");
                // now make sure the original cell is
                // selected…
                r.Select();
            }
        }
        private bool isExcelInteractive()
        {
            try
            {
                // this line does nothing if Excel is not
                // in edit mode. However, trying to set
                // this property while Excel is in edit
                // cell mdoe will cause an exception
                Globals.ThisAddIn.Application.Interactive = Globals.ThisAddIn.Application.Interactive;
                return true; // no exception, ecel is 
                // interactive
            }
            catch
            {
                return false; // in edit mode
            }
        }
        private void xlBringToFront()
        {
            SetForegroundWindow(Globals.ThisAddIn.Application.Hwnd);
        }
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);
