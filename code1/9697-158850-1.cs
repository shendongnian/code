    objExcel = new Excel.Application();
    objBook = (Excel.Workbook)(objExcel.Workbooks.Add(Type.Missing));
    DoSomeStuff(objBook);
    SaveTheBook(objBook);
    objBook.Close(false, Type.Missing, Type.Missing);
    objExcel.Quit();
