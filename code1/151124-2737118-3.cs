    public class FactsheetBase : System.Web.UI.Page 
    { 
    
        public FactsheetBase()
        {
        }
     
        public MyPageData Data { get; set; }  
        protected override void OnLoad(EventArgs e)
        {
            //your code
            // get data that's common to all implementors of FactsheetBase 
            // and store the values in FactsheetBase's properties 
            this.Data = ExtractPageData(Request.QueryString["data"]);             
            base.OnLoad(e);
        }
    }
