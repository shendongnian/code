    public static class CommunicationObjectExtensions
    {
        public static void SafeClose(this ICommunicationObject communicationObject)
        {
            if(communicationObject.State != CommunicationState.Opened)
                return;
            try
            {
                communicationObject.Close();
            }
            catch(CommunicationException ex)
            {
                communicationObject.Abort();
            }
            catch(TimeoutException ex)
            {
                communicationObject.Abort();
            }
            catch(Exception ex)
            {
                communicationObject.Abort();
                throw;
            }
        }
        public static TResult SafeExecute<TServiceClient, TResult>(this TServiceClient communicationObject, 
            Func<TServiceClient, TResult> serviceAction)
            where TServiceClient : ICommunicationObject
        {
            try
            {
                var result = serviceAction.Invoke(communicationObject);
                return result;
            } // try
            finally
            {
                communicationObject.SafeClose();
            } // finally
        }
    }
