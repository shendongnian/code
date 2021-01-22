    public partial class UCSample : UserControl
    {
        public string MyCustomProperty { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(this.MyCustomProperty);
        }
    }
    <%@ Page Language="C#"  %>
    <%@ Register src="UCSample.ascx" tagname="UCSample" tagprefix="uc1"%>
    <uc1:UCSample ID="UCSample1" runat="server" MyCustomProperty="StackOverflow" />
