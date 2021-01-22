    class GenericDisposableHandler<T> where T : IDiposable
    {
        public void DoOperationOnT(T someVariable)
        {
            // Now you can treat T as IDisposable
            someVariable.Dispose();
        }
    }
