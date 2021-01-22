    public partial class Testing: System.Web.UI.Page { 
      protected string ValueFromCodeBehind;
      
      protected void Page_Load(object sender, EventArgs e) {
        
        ValueFromCodeBehind = 
                  Server.HtmlEncode(Server.UrlDecode(Request.QueryString["id"]));
      }
