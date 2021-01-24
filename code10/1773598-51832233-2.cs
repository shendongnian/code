    public class Proxy : MarshalByRefObject {
        public List<String> GetIdentifications() {
            var task = GetIdentificationsAsync();
            return task.Result;
        }
        private Task<List<String>> GetIdentificationsAsync() {
            var tcs = new TaskCompletionSource<List<string>>();
            try {
                var control = new R100DeviceControl();
                Action<List<string>> handler = null;
                handler = result => {
                    // Once event raised then set the 
                    // Result property on the underlying Task.
                    control.OnUserDB -= handler;//optional to unsubscribe from event
                    tcs.TrySetResult(result);
                };
                control.OnUserDB += handler;
                control.Open();
                int count = 0;
                //call async event
                int nResult = control.DownloadUserDB(out count);
            } catch (Exception ex) {
                //Bubble the error up to be handled by calling client
                tcs.TrySetException(ex);
            }
            // Return the underlying Task. The client code
            // waits on the Result property, and handles exceptions
            // in the try-catch block there.
            return tcs.Task;
        }
    }
