    public partial class _Default : System.Web.UI.Page 
    {
        public class Testing
        {
            public string Test { get; set;}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Testing> data = new List<Testing>() 
            {
                new Testing() { Test = "This should print" }
            };
    
            grdHideOnPrint.DataSource = data;
            grdHideOnPrint.DataBind();
        }
    }
