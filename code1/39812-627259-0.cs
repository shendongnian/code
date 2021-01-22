    class MyPage : Page
    {
        public string MyProperty;
    }
    
    class MyUserControl : UserControl
    {
        void Page_Load(object sender, EventArgs e)
        {
            ((MyPage)this.Page).MyProperty //casts Page as the specific page
        }
    }
