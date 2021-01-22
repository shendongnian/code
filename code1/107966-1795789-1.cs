    public partial class MyPage : System.Web.UI.Page, ISpecialPage
    {
        public string Title { get; set; }
        
        public string MetaDescription { get; set; }
        
        public string MetaKeywords { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Some title";
            this.MetaDescription  = "Some description";
            this.MetaKeywords = "Some keywords";
        }
    }
