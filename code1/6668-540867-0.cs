    using System.IO;
    
    namespace Demo
    {
        public partial class StyleSelector : System.Web.UI.Page
        {
            public StyleSelector()
            {
                Me.Load += New EventHandler(doLoad);
            }
            protected void doLoad(object sender, System.EventArgs e)
            {
                // Make sure you add this line
                Response.ContentType = "text/css";
                
                string cssFileName = Request.QueryString("foo");
                
                // I'm assuming you have your CSS in a css/ folder
                Response.WriteFile("css/" + cssFileName + ".css");
            }
        }
    }
