    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Context.Handler is ISpecialPage)
            {
                ISpecialPage specialPage = (ISpecialPage)this.Context.Handler;
                // Logic to read the properties from the ISpecialPage and apply them to the MasterPage here
            }
        }
    }
