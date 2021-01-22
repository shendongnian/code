    public interface ICallbackContract
    {
        void Operation(string arg);
    }
    class Program
    {
        private List<ICallbackContract> Callbacks;
        private void SendMessage(string msg)
        {
            lock (this.Callbacks)
            {
                foreach (var callback in this.Callbacks)
                {
                    this.InvokeWcf(callback, (c) => c.Operation(msg));
                }
            }
        }
        public void InvokeWcf(this ICallbackContract contract, Action<ICallbackContract> op)
        {
            if (((ICommunicationObject)contract).State != CommunicationState.Opened)
            {
                lock (this.Callbacks)
                    Callbacks.Remove(contract);
                myLogger.LogError("That contract isn't open! Disconnected.");
                return;
            }
            try
            {
                op(contract);
            }
            catch (TimeoutException ex)
            {
                lock (this.Callbacks)
                    Callbacks.Remove(contract);
                myLogger.LogError("That contract timed out! Disconnected.", ex);
                return;
            }
            catch (CommunicationException ex)
            {
                ...
            }
            catch (ObjectDisposedException ex)
            {
                ...
            }
        }
    }
