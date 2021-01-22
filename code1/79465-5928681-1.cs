    protected void btnCreateWordBulletin_Click(object sender, EventArgs e)
    {
    String a= Server.MapPath("/Solution/Templates/Sport/Sport.doc"); 
    String b= Server.MapPath("/Solution/Templates/Sport/SportSave.doc"); 
    CreateWordDocument(a, b); 
    }
    protected void CreateWordDocument(object fileName, object saveAs)
    {
        //Set Missing Value parameter - used to represent
        //a missing value when calling methods through interop
        object missing = System.Reflection.Missing.Value;
    //Setup the Word.App class
    Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
    Microsoft.Office.Interop.Word.Document aDoc = null;
    // Check to see that file exists
    if (System.IO.File.Exists((string)fileName))
    {... Activating doc etc...}}
