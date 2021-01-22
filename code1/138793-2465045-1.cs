    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //snip
            MyButton.Click += new EventHandler(delegate (Object o, EventArgs a) 
            {
                //snip
            });
        }
    }
