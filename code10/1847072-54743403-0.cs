    public partial class Service1 : ServiceBase
            {
                public Service1()
                {
                    InitializeComponent();
                }
                Uri uri = new Uri("https://localhost:1017");
                ServiceHost sh = null;
                protected override void OnStart(string[] args)
                {
                    BasicHttpBinding binding = new BasicHttpBinding();
                    binding.Security.Mode = BasicHttpSecurityMode.Transport;
                    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    try
                    {
                        ServiceHost sh = new ServiceHost(typeof(MyService), uri);
                        sh.AddServiceEndpoint(typeof(IService), binding, "");
                        ServiceMetadataBehavior smb;
                        smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                        if (smb == null)
                        {
                            smb = new ServiceMetadataBehavior()
                            {
                                HttpsGetEnabled=true,
                            };
                            sh.Description.Behaviors.Add(smb);
                        }
                        Binding mexbinding = MetadataExchangeBindings.CreateMexHttpsBinding();
                        sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
                        sh.Open();
                        WriteLog($"Service is ready at {DateTime.Now.ToString("hh-mm-ss")}");
                    }
                    catch (Exception e)
                    {
                        WriteLog(e.ToString());
                        throw;
                    }
                }
        
                protected override void OnStop()
                {
                    if (sh!=null&&sh.State==CommunicationState.Opened)
                    {
                        sh.Close();
                        WriteLog($"Service is closed at {DateTime.Now.ToString("hh-mm-ss")}");
                    }
                }
        
                public static void WriteLog(string text)
                {
                    using (StreamWriter sw = File.AppendText(@"C:\Mylog.txt"))
                    {
                        sw.WriteLine(text);
                        sw.Flush();
                    }
                }
            }
            [ServiceContract(Namespace = "mydomain")]
            public interface IService
            {
                [OperationContract]
                string SayHello();
            }
            public class MyService : IService
            {
                public string SayHello()
                {
                    Service1.WriteLog(string.Format("Wow, I have been called at {0}", DateTime.Now.ToString("hh-mm-ss")));
                    return "Hello stranger";
                }
        }
