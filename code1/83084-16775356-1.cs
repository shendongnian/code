     public partial class WebForm : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                string path = Server.MapPath("~");
                path = path + FileUpload1.FileName;
                FileUpload1.SaveAs(path);
                Response.Redirect("WebForm.aspx"); // Responce will be cleared. This Redirection will do the Trick 
                //Put the debugger and check it will work
            }
        }
