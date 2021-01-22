    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void signout_Click(object sender, EventArgs e)
        {
          Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
          Response.Write("<script language=javascript>wnd.close();</script>");
          Response.Write("<script language=javascript>window.open('login.aspx','_parent',replace=true);</script>");
          Session["name"] = null;
        }
    }
