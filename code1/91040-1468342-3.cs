    public partial class Default4 : System.Web.UI.Page, IControlXHost
    {
        public int GetStuff() {
           return 33;
        }
        protected void Page_Load(object sender, EventArgs e) {
            var control = LoadControl("ControlX.ascx");    
        }
    }
