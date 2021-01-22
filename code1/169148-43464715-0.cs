    static bool IsOpened(string wbook)
    {
        bool isOpened = true;
        Excel.Application exApp;
        
        try
        {
            // place the following line here :
            exApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            // because it throws an exception if Excel is not running.
            exApp.Workbooks.get_Item(wbook);
        }
        catch (Exception)
        {
            isOpened = false;
        }
        return isOpened;
    }
