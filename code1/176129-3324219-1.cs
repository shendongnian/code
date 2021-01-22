    using System;
    using System.Text;
    
    namespace WebApplication1
    {
      public partial class _Default : System.Web.UI.Page
      {
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
          {
            txtParam1.Text = Request.QueryString["param1"];
          }
        }
    
        protected void txtParam1_TextChanged(object sender, EventArgs e)
        {
          // Build the new URL with the changed value of TextBox1      
          StringBuilder url = new StringBuilder();
          url.AppendFormat("{0}?param1={1}",
            Request.Path, txtParam1.Text);
    
          // Append all the querystring values that where not param1 to the
          // new URL
          foreach (string key in Request.QueryString.AllKeys)
          {
            if (string.Compare(key, "param1", true) != 0)
            {
              url.AppendFormat("&{0}={1}", key, Request.QueryString[key]);
            }
          }
         
          // Redirect the browser to request the new URL
          Response.Redirect(url.ToString());
        }
      }
    }
