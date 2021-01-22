    protected void Page_Load( object sender, EventArgs e )
    {
    Response.Clear();
    Response.ClearHeaders();
    Response.ContentType = "application/vnd.ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    String shippingFileName = "SomeFile" + DateTime.Now.ToString( "yyyyMMdd" ) + ".csv";
    Response.AddHeader( "Content-Disposition", "attachment; filename=" + shippingFileName );  
    String data = // Create a string that follows the CVS format (use quotes when necessary)
    
    Response.Write(data);
    }
