    using System.Web;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(Name="TestService", ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Service : System.Web.Services.WebService
    {
        public ServiceDetails SDTest;
        [WebMethod]
        [SoapDocumentMethod(Binding = "TestService")]
        [SoapHeader("SDTest", Required = true)]
        public string DoMyThing()
        {
            return "";
        }
    }
    public class ServiceDetails : System.Web.Services.Protocols.SoapHeader
    {
        public string ID { get; set; }
        public string Auth { get; set; }
    }
