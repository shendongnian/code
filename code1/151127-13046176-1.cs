     public partial class PerformanceFactsheet : FactsheetBase
    {
        public PerformanceFactsheet()
        {
            this.Load += new EventHandler(this.Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            divPerformance.Controls.Add(this.Data);
        }
    }
    public abstract class FactsheetBase : System.Web.UI.Page
    {
        public MyPageData Data { get; set; }
        public FactsheetBase()
        {
            this.Load += new EventHandler(this.Page_Load);
        }
        new protected void Page_Load(object sender, EventArgs e)
        {            
            this.Data = ExtractPageData(Request.QueryString["data"]);
        }
    }
