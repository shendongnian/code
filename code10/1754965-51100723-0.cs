    public abstract class MyClass
    {
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
                    SomethingUnique1();
                }
                // Request failed. Call the onError callback if provided
                else { onError?.Invoke(request); }
            };
    
            // Remove idle state
            state.Remove(State.Idle);
    
            SomethingUnique2(callback);
        }
        protected abstract void SomethingUnique1();
        protected abstract void SomethingUnique2(Action<TcpRequest> callback);
    }
