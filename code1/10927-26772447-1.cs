    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Diagnostics;
    
    namespace btnproce
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                string t ="Balotelli";
                Process.Start("http://google.com/search?q=" + t);
            }
        }
    }
