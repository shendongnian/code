    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Test : System.Web.Services.WebService
    {
        public class Cat
        {
            public String HairType { get; set; }
            public int MeowVolume { get; set; }
            public String Name { get; set; }
        }
        [WebMethod]
        public String MyMethodA(Cat cat)
        {
            return "return value does not matter";
        }
        [WebMethod]
        public Cat MyMethodB(String someParam)
        {
            return new Cat() { HairType = "Short", MeowVolume = 13, Name = "Felix the Cat" };
        }
    }
