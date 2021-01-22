    using System;
    using System.Web;
    using System.Collections;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    /// <summary>
    /// Summary description for StockQuote
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class StockQuote : System.Web.Services.WebService {
        public StockQuote () {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        [WebMethod]
        public decimal GetStockQuote(string ticker)
        {
            //perform database lookup here
            return 8;
        }
        [WebMethod]
        public string HelloWorld() {
            return "Hello World";
        }
        
    }
