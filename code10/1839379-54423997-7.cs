    namespace LargeMessageService
    {
        [ServiceContract]
        public interface ILobService
        {
            [OperationContract]
            [WebGet]
            string EchoWithGet(string s);
            [OperationContract]
            [WebInvoke]
            string EchoWithPost(string s);
        }
        public class LobService : ILobService
        {
            public string EchoWithGet(string s)
            {
                return "You said " + s;
            }
            public string EchoWithPost(string s)
            {
                return "You said " + s;
            }
        }
    }
