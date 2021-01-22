[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MyService : System.Web.Services.WebService
{
  [WebMethod]
  public string HelloWorld()
  {
    return "Hello World";
  }
}
