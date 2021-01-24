    public class Proxy : MarshalByRefObject
    { 
        ConcurrentBag<string> _results = new ConcurrentBag<string>();
        public void Open()
        {
            var control = new R100DeviceControl();
            control.OnUserDB += Control_OnUserDB;
            control.Open();
            // you may need to store nResult and count in a field?
            nResult = control.DownloadUserDB(out int count);
        }
        public List<String> GetIdentifications()
        {
            var copy = new List<string>();
            while (_results.TryTake(out var x))
            {
               copy.Add(x);
            }             
            return copy;
        }
        private void Control_OnUserDB(List<String> result)
        {
            // Get the list of string from here
            _results.Add (result);
        }
    }
