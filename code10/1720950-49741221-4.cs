    private class DummyResponseFeature : IHttpResponseFeature {
        public Stream Body { get; set; }
        public bool HasStarted { get { return hasStarted; } }
        public IHeaderDictionary Headers { get; set; }
        public string ReasonPhrase { get; set; }
        public int StatusCode { get; set; }
        public void OnCompleted(Func<object, Task> callback, object state) {
            //...No-op
        }
        public void OnStarting(Func<object, Task> callback, object state) {
            this.callback = callback;
            this.state = state;
        }
        
        bool hasStarted = false;
        Func<object, Task> callback;
        object state;
        
        public Task InvokeCallBack() {
            hasStarted = true;
            return callback(state);
        }
    }
    
