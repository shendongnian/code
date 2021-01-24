    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	namespace tempApp
	{
		public partial class WebForm2 : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				var styleControl = new HtmlGenericControl();
				styleControl.TagName = "style";
				styleControl.Attributes.Add("type", "text/css");
				styleControl.InnerHtml = "h1 { color: red; }";
				Page.Header.Controls.Add(styleControl);
				var scriptControl = new HtmlGenericControl();
				scriptControl.TagName = "script";
				scriptControl.Attributes.Add("type", "text/javascript");
				scriptControl.InnerHtml = "alert('Hello World')";
				Page.Header.Controls.Add(scriptControl);
			}
		}
	}
    
