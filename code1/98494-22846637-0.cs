    Application aXL = new Application();
    aXL.FileValidation = 
        Microsoft.Office.Core.MsoFileValidationMode.msoFileValidationSkip;
    try {
         Workbook aBook = aXL.Workbooks.Open("K:\\Work\\ExcelTest\\BrokenMacro.xls"
                        , 0
                        , true
                        , Type.Missing
                        , Type.Missing
                        , Type.Missing
                        , true
                        , Type.Missing
                        , Type.Missing
                        , false
                        , false
                        , Type.Missing
                        , false
                        , false
                        , Type.Missing
                        /*,false*/);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
