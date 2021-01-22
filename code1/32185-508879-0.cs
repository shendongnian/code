    public class MyBaseControl : System.Web.UI.UserControl
    {
        public string MyProperty 
        {
            get { return ViewState["MyProp"] as string; }
            set { ViewState["MyProp"] = value; }
        }
    }
