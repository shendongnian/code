    public partial class Test1 : System.Web.UI.UserControl
    {
        public string CurrentValue
        {
            get { return (string)ViewState["CurrentValue"] ?? string.Empty; }
            set { ViewState["CurrentValue"] = value; }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            writer.Write(this.CurrentValue);
        }
    }
