     class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:2000");
            WebHttpBinding binding = new WebHttpBinding();
            using (ServiceHost sh=new ServiceHost(typeof(MyService),uri))
            {
                ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IService), binding, "");
                se.EndpointBehaviors.Add(new WebHttpBehavior());
                Console.WriteLine("service is ready....");
                sh.Open();
                Console.ReadLine();
                sh.Close();
            }
        }
    }
    [ServiceContract(ConfigurationName ="isv")]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Xml,
       RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate ="BookInfo/")]
        BookingResult Booking(BookInfo bookInfo);
    }
    [ServiceBehavior(ConfigurationName = "sv")]
    public class MyService : IService
    {
        
        public BookingResult Booking(BookInfo bookInfo)
        {
            BookingResult result = new BookingResult();
            if (bookInfo==null)
            {
                result.isSucceed = false;
            }
            else
            {
                result.isSucceed = true;
            }
            return result;
        }
    }
    [DataContract]
    public class BookInfo
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class BookingResult
    {
        [DataMember]
        public bool isSucceed { get; set; }
    }
