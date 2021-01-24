    public void RunActualsMacro(string Filepath, string Period, String FiscalYear)
    {
        //~~> Define your Excel Objects
        Excel.Application xlApp = null;
        Excel.Workbook xlWorkBook;
        //~~> Start Excel and open the workbook.
        //handle errors below
        try {
            xlApp = (Excel.Application) System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        } catch {
            //perhaps exit - or throw??
        }
        xlWorkBook = xlApp.Workbooks["Transactions into LV Template.xlsm"];
        // Populat Cells A1,A2,A3 with string variables
        Excel.Worksheet ws = xlWorkBook.Worksheets["Sheet1"] //what the tab name of sheet
        ws.Cells[1, 1] = Filepath;
        ws.Cells[2, 1] = Period;
        ws.Cells[3, 1] = FiscalYear;
        //~~> Run the macro ControlMacroAct
        xlApp.Run("ControlMacroACT");
        //~~> Clean-up: Close the workbook
        xlWorkBook.Close(false);
        //~~> Quit the Excel Application
        xlApp.Quit();
    }
