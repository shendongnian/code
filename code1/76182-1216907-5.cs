    public class DebugMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            EventLog.Instance().Debug("Amazon", request.ToString()); // custom logger
            return null;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
