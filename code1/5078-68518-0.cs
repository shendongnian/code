using System;
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("var tinyMCELinkList = new Array(");
        // put all of your links here in the right format..
        Response.Write(string.Format("['{0}', '{1}']", "name", "url"));
        Response.Write(");");
    }
}
