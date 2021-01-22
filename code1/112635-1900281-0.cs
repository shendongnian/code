    public class MyMasterPage : MasterPage
    {
        public string MyMenuProperty { get; set; }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (MyMenuProperty == "comedy")
            {
                /* do your menu stuff */
            }
        }
    }
    public class MyContentPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myMaster = Page.Master as MyMasterPage;
            if (myMaster != null)
            {
                myMaster.MyMenuProperty = "comedy";
            }
        }
