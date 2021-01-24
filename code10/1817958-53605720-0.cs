    //Default.aspx
    <!DOCTYPE html>
    <%@ Page Language="C#" AutoEventWireup="true" Inherits="SomeApp.MyPage" %>
    <%-- No CodeBehind. inherits external class--%>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server" ID="lblTest"></asp:Label><br />
                <asp:Button runat="server" ID="btnTest" Text="click me" OnClick="btnTest_Click" />
            </div>
        </form>
    </body>
    </html>
    //App_Code\MyPage.cs
    namespace SomeApp
    {
        public partial class MyPage : System.Web.UI.Page
        {
            //You need to declare all page controls referred by code here
            public System.Web.UI.WebControls.Label lblTest { get; set; }
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    lblTest.Text = "hello world from app_code";
                }
            }
        }
    }
    //App_code\AnotherFile.cs
    namespace SomeApp
    {
        public partial class MyPage : System.Web.UI.Page
        {
            protected void btnTest_Click(object sender, EventArgs e)
            {
                    lblTest.Text = "hello world from btnTest_Click";
    
            }
        }
    }
