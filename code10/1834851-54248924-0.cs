     public class MyClientMessageInspector : IClientMessageInspector
    {
              Your message box
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
           show message in your message box
        }
        public MyClientMessageInspector ( ){
                           }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
    }
