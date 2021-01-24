    class MyClass : IDisposable
    {
        private Action<string, string> HubConnectionOnDelegate;
        private void InitOrSomething()
        {
            //Pointer to a method, anonymous method, whatever...
            HubConnectionOnDelegate = HubConnection_On;
        }
        private static void HubConnection_On(string user, string message)
        {
            var finalMessage = $"{user} says {message}";
            // Update the UI
        }
        private void Elsewhere()
        {
            hubConnection.On<string, string>(ReceiveMethodKey, HubConnectionOnDelegate);
        }
        public void Dispose()
        {
            HubConnectionOnDelegate = null;
        }
    }
