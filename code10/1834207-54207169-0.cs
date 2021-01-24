    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public Repeater _ARepeater
        {
            get
            {
                return ARepeater;
            }
            set
            {
                ARepeater = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
