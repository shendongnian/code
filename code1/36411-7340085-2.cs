    public class AutoCloseWcf : IDisposable
    {
        private ICommunicationObject CommunicationObject;
        public AutoDisconnect(ICommunicationObject CommunicationObject)
        {
            this.CommunicationObject = CommunicationObject;
        }
        public void Dispose()
        {
            if (CommunicationObject == null)
                return;
            try {
                if (CommunicationObject.State != CommunicationState.Faulted) {
                    CommunicationObject.Close();
                } else {
                    CommunicationObject.Abort();
                }
            } catch (CommunicationException ce) {
                CommunicationObject.Abort();
            } catch (TimeoutException toe) {
                CommunicationObject.Abort();
            } catch (Exception e) {
                CommunicationObject.Abort();
                //Perhaps log this
            } finally {
                CommunicationObject = null;
            }
        }
    }
