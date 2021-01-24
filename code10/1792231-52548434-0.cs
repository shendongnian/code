    Scripting.Dictionary dict = new Scripting.Dictionary();
    dict.Add("Apples", 50);
    dict.Add("Oranges", 60);
    Excel.Application xlApp = new Excel.Application();
    Excel.Workbook xlWorkBook;
    // ~~> Opens an existing Workbook. Change path and filename as applicable
    xlWorkBook = xlApp.Workbooks.Open("C:\\Sample.xlsm");
    // ~~> Display Excel
    xlApp.Visible = true;
    xlApp.Run("ShowDict", dict);
