    using Microsoft.Office.Interop.Excel;
    Application Xl = (Application) ExcelDnaUtil.Application;
    DropDown box;
    try
    {
        box = Xl.ActiveWorkBook.Sheets["Sheet1"].DropDowns("Box 1");
    }
    catch (Exception e)
    {
        Log.Fatal("Failed to find drop down called 'Box 1' on sheet", e);
        throw;
    }
    try
    {
    	box.Selected = 1;
    }
    catch (Exception e)
    {
        Log.Fatal("Failed to set value of drop down", e);				
        throw;
    }
