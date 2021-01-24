    using System.Web.UI.WebControls;
    public partial class myControl : System.Web.UI.UserControl
    {
        public string variable { get; set; }
        public void start(string parameter)
        {
            variable = parameter;
        }
    }
