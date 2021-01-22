    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld(Foo foo)
        {
            return "Hello World";
        }
    }
