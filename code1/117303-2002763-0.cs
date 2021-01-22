    public class ChangeNotifier : IDisposable
    {
        LdapConnection _connection;
        HashSet<IAsyncResult> _results = new HashSet<IAsyncResult>();
    
        public ChangeNotifier(LdapConnection connection)
        {
            _connection = connection;
            _connection.AutoBind = true;
        }
        public void Register(string dn, SearchScope scope)
        {
            SearchRequest request = new SearchRequest(
                dn, //root the search here
                "(objectClass=*)", //very inclusive
                scope, //any scope works
                null //we are interested in all attributes
                );
        
            //register our search
            request.Controls.Add(new DirectoryNotificationControl());
            //we will send this async and register our callback
            //note how we would like to have partial results
            IAsyncResult result = _connection.BeginSendRequest(
                request,
                TimeSpan.FromDays(1), //set timeout to a day...
                PartialResultProcessing.ReturnPartialResultsAndNotifyCallback,
                Notify,
                request);
            //store the hash for disposal later
            _results.Add(result);
        }
        private void Notify(IAsyncResult result)
        {
            //since our search is long running, we don't want to use EndSendRequest
            PartialResultsCollection prc = _connection.GetPartialResults(result);
        
            foreach (SearchResultEntry entry in prc)
            {
                OnObjectChanged(new ObjectChangedEventArgs(entry));
            }
        }
        private void OnObjectChanged(ObjectChangedEventArgs args)
        {
            if (ObjectChanged != null)
            {
                ObjectChanged(this, args);
            }
        }
        public event EventHandler<ObjectChangedEventArgs> ObjectChanged;
        #region IDisposable Members
        public void Dispose()
        {
            foreach (var result in _results)
            {
                //end each async search
                _connection.Abort(result);
           }
        }
 
        #endregion
    }
 
    public class ObjectChangedEventArgs : EventArgs
    {
        public ObjectChangedEventArgs(SearchResultEntry entry)
        {
            Result = entry;
        }
        public SearchResultEntry Result { get; set;}
    }
