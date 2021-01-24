<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
**1. Session** 
When user Click on the `Button` it'll call it's `OnClick` and will save the `Username` in session.  
protected void btnLogin_Click(object sender, EventArgs e)
{
     Session["UserName"] = txtUsername.Text;
     Response.Redirect("~/Page2.aspx");
}
And you can retrieve the information in the next page of Page_Load event. 
lblWelcome.Text = Session["UserName"].ToString():
**2. Query String**
Query string is like passing data using the URL
protected void btnLogin_Click(object sender, EventArgs e)
{
     Response.Redirect("~/Page2.aspx?user="+txtUsername.Text);
}
You can retrieve the parameter from the Link like this. 
lblWelcome.Text = Request.QueryString["user"];
That's what mostly used, some programmers use Cookies to pass data from one page to another. It depends on the scenario.  
