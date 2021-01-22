    private void OpenExcel(string inFileName) {
        Excel.Application xlApp = null;
        try {
            xlApp = new Excel.ApplicationClass();
            Excel.Workbook xlBook = xlApp.Workbooks.Open(inFileName
                , Type.Missing, Type.Missing, Type.Missing, Type.Missing
                , Type.Missing, Type.Missing, Type.Missing, Type.Missing
                , Type.Missing, Type.Missing, Type.Missing, Type.Missing
                , Type.Missing, Type.Missing);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];
            xlApp.Quit();
        } finally {
            ComHelper.Release(ref xlApp);
        }
    }
