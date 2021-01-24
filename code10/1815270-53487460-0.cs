    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace WinForms
    {
    	public partial class Form1 : Form
    	{
    
    		// Hold reference to Excel
    		private Process xlProc = null;
    
    		private void OnRun(object sender, EventArgs e)
    		{
    			Task.Run(() =>
    			{
    				// Create new instance of EXCEL.EXE
    				var xlApp = new Excel.Application { Visible = true };
    
    				// Get Excel proccess in order to kill it
    				var handle = new IntPtr(xlApp.Hwnd);
    				xlProc = Process.GetProcesses().Where(p => p.MainWindowHandle == handle).First();
    
    				// Create new workbook
    				var xlBook = xlApp.Workbooks.Add();
    				var xlSheet = xlBook.Sheets[1] as Excel.Worksheet;
    
    				// Do some operation
    				xlSheet.Cells[1].Value = "Hello from .NET!";
    
    				// Quit
    				xlBook.Close(SaveChanges: false);
    				xlApp.Quit();
    
    				Marshal.ReleaseComObject(xlApp);
    				Marshal.ReleaseComObject(xlBook);
    				Marshal.ReleaseComObject(xlSheet);
    
    				GC.Collect();
    				GC.WaitForFullGCComplete();
    
    				KillExcel();
    
    			});
    		}
            // Kill Excel process if it still exists
    		private void KillExcel()
    		{
    			if (!xlProc.HasExited)
    			{
    				xlProc.Kill();
    			}
    		}
    	}
    }
