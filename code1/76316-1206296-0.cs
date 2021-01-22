    // We need this name space to use HtmlGenericControl
    using System.Web.UI.HtmlControls;
     
    namespace TestWebApp
    {
     
          public class WebForm1 : System.Web.UI.Page
          {
                // Variable declaration and instantiation
                protected HtmlGenericControl PageTitle = new HtmlGenericControl();
     
                private void Page_Load(object sender, System.EventArgs e)
                {
                      // Set new page title
                      PageTitle.InnerText = "New Page Title";
                }
          }
    }
