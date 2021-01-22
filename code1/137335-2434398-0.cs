    // need this for the AsyncResult class below
    using System.Runtime.Remoting.Messaging;
    public class BaseContextMenu<T> : IContextMenu
    {
        private T executor;
        
        public void Exec(Action<T> action) {
            action.Invoke(this.executor);
        }
       
        public void ExecAsync(Action<T> asyncAction) {
            // specify what method to call when asyncAction completes
            asyncAction.BeginInvoke(this.executor, ExecAsyncCallback, null);
        }
        
        // this method gets called at the end of the asynchronous action
        private void ExecAsyncCallback(IAsyncResult result) {
            var asyncResult = result as AsyncResult;
            if (asyncResult != null) {
                var d = asyncResult.AsyncDelegate as Action<T>;
                if (d != null)
                    // all calls to BeginInvoke must be matched with calls to
                    // EndInvoke according to the MSDN documentation
                    d.EndInvoke(result);
            }
        }
    }
