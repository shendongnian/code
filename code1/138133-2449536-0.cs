    //Excel Application Object
    Microsoft.Office.Interop.Excel.Application oExcelApp;
    
    this.Activate ( );
    
    //Get reference to Excel.Application from the ROT.
    oExcelApp = ( Microsoft.Office.Interop.Excel.Application ) System.Runtime.InteropServices.Marshal.GetActiveObject ( "Excel.Application" );
    
    //Display the name of the object.
    MessageBox.Show ( oExcelApp.ActiveWorkbook.FullName );
    
    //Release the reference.
    oExcelApp = null;
