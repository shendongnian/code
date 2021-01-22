    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.PostBackUrl = string.Empty;
            this.Button1.Click += new EventHandler(this.Button1_Click);
            this.CustomValidator1.ServerValidate += new ServerValidateEventHandler(this.CustomValidator1_ServerValidate);
        }
        void Button1_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                this.Response.Redirect("~/page2.aspx");
            }
        }
        void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // validation logic here
        }
    }
