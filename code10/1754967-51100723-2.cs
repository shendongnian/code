    public sealed class MyClass
    {
        private readonly Action somethingUnique1;
        private readonly Action<TcpRequest> somethingUnique2;
        public MyClass(Action somethingUnique1, Action<TcpRequest> somethingUnique2)
        {
            this.somethingUnique1 = somethinUnique1;
            this.somethinUnique2 = somethingUnique2;
        }
        public void MyFunction(string apples, Action<TcpRequest> onSuccess=null, Action<TcpRequest> onError=null)
        {
            // Throw exception if already busy with an operation
            if (!state.Has(State.Idle)) { throw new OperationInProgress(); }
    
            // Define callback action
            Action<TcpRequest> callback = delegate (TcpRequest request)
            {
                // Add idle state back in
                state.Add(State.Idle);
    
                // Check if the request succeeded
                if (request.OK)
                {
                    somethingUnique1();
                }
                // Request failed. Call the onError callback if provided
                else { onError?.Invoke(request); }
            };
    
            // Remove idle state
            state.Remove(State.Idle);
    
            somethingUnique2(callback);
        }
    }
