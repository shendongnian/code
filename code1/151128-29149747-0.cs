         public partial class PerformanceFactsheet : FactsheetBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
    base.Page_Load(sender, e);
            // do stuff with the data extracted in FactsheetBase
            divPerformance.Controls.Add(this.Data);
        }
    }
    public class FactsheetBase : System.Web.UI.Page
    {
        public MyPageData Data { get; set; } 
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            // get data that's common to all implementors of FactsheetBase
            // and store the values in FactsheetBase's properties
            this.Data = ExtractPageData(Request.QueryString["data"]);            
        }
    }
