    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.HtmlControls;
	using System.Web.UI.WebControls;
	namespace tempApp
	{
		public partial class WebForm1 : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				litHeader.Text = @"
					<style>h1 { color: red; }</style>
					<script>alert('Hello World')</script>
				";            
			}
		}
	}
