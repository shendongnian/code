    public partial class todo : System.Web.UI.UserControl
    {
        private string mysecondteststring;
        public string setValue
        {
            get
            {
                return mysecondteststring;
            }
            set
            {
                mysecondteststring = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // my code
        }
    }
