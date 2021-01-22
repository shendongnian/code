    class Controller
    {
        public ProcessRequest(String action, String serializedRequest)
        {
            IHandler handler = GetHandlerForAction(action);
            IRequest request = 
                serializer.Deserialize<handler.GetRequestType()>(serializedRequest);
            handler(this.Model, request);
        }
    }
