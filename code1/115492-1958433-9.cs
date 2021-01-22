    // Note:
    // using System.Runtime.InteropServices;
    object excelApp = 
        Marshal.GetActiveObject("Excel.Application");
    
    object activeSheet = 
        excelApp
            .GetType()
            .InvokeMember(
                "ActiveSheet", 
                BindingFlags.GetProperty, 
                null, 
                excelApp, 
                null);
