    public class FactsheetBase : System.Web.UI.Page 
    { 
    
        public FactsheetBase()
        {
            this.Load += new EventHandler(this.Page_Load);
        }
     
        public MyPageData Data { get; set; }  
        protected void Page_Load(object sender, EventArgs e) 
        { 
            // get data that's common to all implementors of FactsheetBase 
            // and store the values in FactsheetBase's properties 
            this.Data = ExtractPageData(Request.QueryString["data"]);             
        } 
    }
