    [ParseChildren(true, "Text")] //Store inner content in Text property
    [PersistChildren(false)]      //Don't automatically render inner content
    public partial class div : System.Web.UI.UserControl
    {
        public string Text { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            litText.Text = Text;  //Render it however you want
        }
    }
