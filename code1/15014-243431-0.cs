    partial class EWTD : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(GetPDF());
        }
        
        protected byte[] GetPDF()
        {
            // Here you will retrieve the PDF as an array of bytes
        }
        
    }
