    [ServiceContract, DispatchByBodyBehavior]
    public class Server : IServer
    {
        [OperationContract]
        public Action1Response Action1(Action1Request request)
        {
            //Do stuff here
        }
    
        [OperationContract]
        public Action2Response Action2(Action2Request request)
        {
            //Do stuff here
        }
    }
