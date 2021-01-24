    var excelApp =  (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
    var range = (Excel.Range)workSheet.Range[workSheet.Range["B2"],
            workSheet.Range["B2"].End[Excel.XlDirection.xlDown]];
    var cellData = (Object[,])range.Value2;
    string result = "";
    foreach (var cell in cellData) {
        result += cell.ToString();
    }
