        [WebService(Namespace = "http://MyNameSpace")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.Web.Script.Services.ScriptService]
        public class Web : System.Web.Services.WebService{
    	   
           [WebMethod]
    	   public string TestMethod(){
             return "Testing";
           }
        }
