    public partial class ImageGrab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                byte[] byteData = new byte[0];
    
                // fetch the value of parameter into the byte array
    
                string seq_id = Request.QueryString["seqid"];
    
                if (string.IsNullOrEmpty(seq_id))
                {
                    seq_id = "214";
                }
    
                byteData = DBManager.GetBinaryData(seq_id);
    
                Response.Clear();
    
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(byteData);
                Response.End();
            }
            catch (Exception exc)
            {
                Response.Write(exc.Message);
            }
        }
    
    }
