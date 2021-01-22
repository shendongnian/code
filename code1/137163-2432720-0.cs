    private void Merge(string strSourceFolder, string strDestinationFile)
    {
        try
        {
            //1. Validate folder,
            //2. Instantiate excel object
            //3. Loop through the files
            //4. Add sheets
            //5. Save and enjoy!
    
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            ExcelApp.Visible = false;
    
            //Create destination object
            Microsoft.Office.Interop.Excel.Workbook objBookDest = ExcelApp.Workbooks.Add(missing);
    
    
            foreach (string filename in Directory.GetFiles(strSourceFolder))
            {
                if (File.Exists(filename))
                {
                    //create an object
                    Microsoft.Office.Interop.Excel.Workbook objBookSource = ExcelApp.Workbooks._Open
                  (filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                  , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
    
                    //Browse through all files.
                    foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in objBookSource.Worksheets)
                    {
                        sheet.Copy(Type.Missing, objBookDest.Worksheets[objBookSource.Worksheets.Count]);
                    }
    
                    objBookSource.Close(Type.Missing, Type.Missing, Type.Missing);
                    objBookSource = null; 
    
                }
            }
            objBookDest.SaveAs(strDestinationFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            objBookDest.Close(Type.Missing, Type.Missing, Type.Missing);
           
            objBookDest = null;
            ExcelApp = null;
    
    
        }
        catch (System.Exception e)
        {
            //Catch
        }
    }
