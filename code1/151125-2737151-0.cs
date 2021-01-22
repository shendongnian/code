    public partial class PerformanceFactsheet : FactsheetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load( sender, e );
            // do stuff with the data extracted in FactsheetBase
            divPerformance.Controls.Add(this.Data);
        }
    }
