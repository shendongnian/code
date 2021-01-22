    //Set Missing Value parameter - used to represent
    //a missing value when calling methods through interop
    object missing = System.Reflection.Missing.Value;
    //Setup the Word.App class
    Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
    Microsoft.Office.Interop.Word.Document aDoc = null;
    // Check to see that file exists
    if (System.IO.File.Exists((string)fileName))
    {... Activating doc etc...}}
