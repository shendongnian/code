    using Excel = Microsoft.Office.Interop.Excel;
    using ExcelTools = Microsoft.Office.Tools.Excel;
    public void AddButtonToWorksheet()
    {
      Excel.Worksheet worksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
      ExcelTools.Worksheet vstoSheet = Globals.Factory.GetVstoObject(worksheet);
      Button button = new Button();
      button.Text = "Dynamic Button!";
      vstoSheet.Controls.AddControl(
        button, 50, 50, 100, 50, "TestButton");
    }
