    [ServiceContract]
    public interface IService1
    {
        [WebGet]
        [OperationContract]
        string Echo(string echoThis);
    }
    public class Service1 : IService1
    {
        public string Echo(string echoThis)
        {
            return string.Format("You sent this '{0}'.", echoThis);
        }
    }
