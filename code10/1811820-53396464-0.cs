    public class ServerConnection
    {
        public TReturn Result<TReturn, TChannel>([CanBeNull] TReturn defaultReturn, TChannel clientChannel, [CanBeNull] params object[] p)
        {
          //ignore these 3 lines if your just want the method by name
            var stackTrace = new StackTrace();
            var callerMethod = stackTrace.GetFrame(1).GetMethod();
            var methodName = callerMethod.Name;
   
            var result = defaultReturn;
            try
            {
                var channelType = typeof(TChannel);
                var theMethod = channelType.GetMethod(methodName);
                var client = (IClientChannel)clientChannel;
                result = (TReturn)theMethod?.Invoke(client, p);
                client.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error processing your request\n\nAny data received may be Inaccurate");
                //Ignored
            }
            return result;
        }
    }
