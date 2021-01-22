    ...
        public partial class Default : System.Web.UI.Page
        {
            protected string PlotKitData = "[]";
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack) PlotKitData = GenerateJSON();
    ...
