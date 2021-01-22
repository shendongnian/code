    public Excel.Application StartExcel()
    {
        Excel.Application instance = null;
        try
        {
           instance = (Excel.Application System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
           instance = new Excel.ApplicationClass();
        }
        return instance;
    }
