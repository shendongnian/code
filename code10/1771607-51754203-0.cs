    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook book = null;
    bool status = false;
    try 
        { 
        var originalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CodigoInteligente" , "Originales" , "Articulos.xls");
        var oldFile = new FileInfo(originalPath);
        if (!oldFile.Exists)
            {
                return false;
            }
        var newPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CodigoInteligente", "Articulos.xls");
        var newFile = new FileInfo(newPath);
        if (newFile.Exists)
            {
            if (IsFileLocked(newFile))
                {
                    return false;
                }
            newFile.Delete();
            }
        book = xlApp.Workbooks.Open(originalPath);
        book.SaveAs(newPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet);
        status = true;
        }
        catch(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Hubo un error");
            Logs.agregarLog(ex);
            return false;
        }
        finally
            {                
            book.Close(false);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
    return status;
