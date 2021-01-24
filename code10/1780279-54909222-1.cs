    public class MessageLoggingInspector : IClientMessageInspector
        {
            private readonly string _serviceName;
            public MessageLoggingInspector(string serviceName)
            {
                _serviceName = serviceName;
            }
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                // copying message to buffer to avoid accidental corruption
                var buffer = reply.CreateBufferedCopy(int.MaxValue);
                reply = buffer.CreateMessage();
                // creating copy
                var copy = buffer.CreateMessage();
                //getting full input message
                var fullInputMessage = copy.ToString();
    
            }
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                // copying message to buffer to avoid accidental corruption
                var buffer = request.CreateBufferedCopy(int.MaxValue);
                request = buffer.CreateMessage();
                // creating copy
                var copy = buffer.CreateMessage();
                //getting full output message
                var fullOutputMessage = copy.ToString();
                return null;
            }
        }
