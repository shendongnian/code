	public class Target : Page
	{
		protected override void Page_Load(object sender, EventArgs e)
		{
            Response.Write("<b><u>Request.Form.Keys</u></b><br>");
            Response.Write("<ul>");
            foreach (var key in Request.Form.AllKeys)
            {
                Response.Write(string.Format(
                  "<li>Key: '{0}'    Value: '{1}'", key, Request.Form[key]));
            }
            Response.Write("</ul>");
			// flush
			Response.Flush();
		}
	}
