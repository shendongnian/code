    internal class MessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
    private void LogMessage(ref msg, bool request)
    {
      Console.WriteLine(string.Format("{0}", received ? "Request" : "Response"));
    }
        #region IClientMessageInspector
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            LogMessage(ref reply, false);
        }
        public object BeforeSendRequest(ref Message request, System.ServiceModel.IClientChannel channel)
        {
            LogMessage(ref request, true);
            return null;
        }
        #endregion
        //Service message inspection        
        #region IDispatchMessageInspector
        public object AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            LogMessage(ref request, true);
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            LogMessage(ref reply, false);
        }
        #endregion
    }
