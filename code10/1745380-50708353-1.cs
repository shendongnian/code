    var app = new Microsoft.Office.Interop.Excel.Application();
    var workbook = app.Workbooks.Open(@"test.xlsm");
    try
    {
        CallSub(workbook, "DivByZero");
    }
    catch(DivideByZeroException dbz)
    {
        Console.WriteLine(dbz.Message);
    }
