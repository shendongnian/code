    public partial class MyMaster : MasterPage
    {
        public string MyString { get; set; }
    }
    
    public partial class MyPage : Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MyMaster)(this.Master)).MyString = "some value";
        }
    }
