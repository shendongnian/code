    class DataConcierge<T>
    {
        // *************************
        // Simple save functionality
        // *************************
        public void Save(T dataObject)
        {
            // perform save logic
            this.OnSaved(dataObject);
        }
        public event DataObjectSaved<T> Saved;
        protected void OnSaved(T dataObject)
        {
            if (this.Saved != null)
                this.Saved(this, new DataObjectEventArgs<T>(dataObject));
        }
        // ************************
        // Batch save functionality
        // ************************
        Dictionary<BatchToken, List<T>> _BatchSavedDataObjects = new Dictionary<BatchToken, List<T>>();
        object _BatchSavedDataObjectsLock = new object();
        int _SavedObjectThreshold = 20; // if the number of objects being stored for a batch reaches this threshold, then those objects are to be cleared from the list.
        public BatchToken BeginSave()
        {
            // create a batch token to represent this batch
            BatchToken token = new BatchToken();
            lock (_BatchSavedDataObjectsLock)
            {
                _BatchSavedDataObjects.Add(token, new List<T>());
            }
            return token;
        }
        public void EndSave(BatchToken token)
        {
            this.OnBatchSaved(token); // this causes a single BatchSaved event to be fired
            lock (_BatchSavedDataObjectsLock)
            {
                if (!_BatchSavedDataObjects.Remove(token))
                    throw new ArgumentException("The BatchToken is expired or invalid.", "token");
            }
        }
        public void Save(BatchToken token, T dataObject)
        {
            List<T> batchSavedDataObjects;
            lock (_BatchSavedDataObjectsLock)
            {
                if (!_BatchSavedDataObjects.TryGetValue(token, out batchSavedDataObjects))
                    throw new ArgumentException("The BatchToken is expired or invalid.", "token");
            }
            // perform save logic
            // add the data object to the list storing the data objects that have been saved for this batch
            lock (batchSavedDataObjects)
            {
                batchSavedDataObjects.Add(dataObject);
                this.OnBatchSaved(batchSavedDataObjects);
            }
        }
        public event BatchDataObjectSaved<T> BatchSaved;
        protected void OnBatchSaved(BatchToken token)
        {
            List<T> batchSavedDataObjects;
            lock (_BatchSavedDataObjectsLock)
            {
                if (!_BatchSavedDataObjects.TryGetValue(token, out batchSavedDataObjects))
                    throw new ArgumentException("The BatchToken is expired or invalid.", "token");
            }
            if (this.BatchSaved != null)
                this.BatchSaved(this, new BatchDataObjectEventArgs<T>(batchSavedDataObjects));
        }
        protected void OnBatchSaved(List<T> batchSavedDataObjects)
        {
            // if the threshold has been reached
            if (_SavedObjectThreshold > 0 && batchSavedDataObjects.Count >= _SavedObjectThreshold)
            {
                // then raise the BatchSaved event with the data objects that we currently have
                if (this.BatchSaved != null)
                    this.BatchSaved(this, new BatchDataObjectEventArgs<T>(batchSavedDataObjects.ToArray()));
                // and clear the list to ensure that we are not holding on to the data objects unnecessarily
                batchSavedDataObjects.Clear();
            }
        }
    }
    class BatchToken
    {
        static int _LastId = 0;
        static object _IdLock = new object();
        static int GetNextId()
        {
            lock (_IdLock)
            {
                return ++_LastId;
            }
        }
        public BatchToken()
        {
            this.Id = GetNextId();
        }
        public int Id { get; private set; }
    }
    class DataObjectEventArgs<T> : EventArgs
    {
        public T DataObject { get; private set; }
        public DataObjectEventArgs(T dataObject)
        {
            this.DataObject = dataObject;
        }
    }
    delegate void DataObjectSaved<T>(object sender, DataObjectEventArgs<T> e);
    class BatchDataObjectEventArgs<T> : EventArgs
    {
        public IEnumerable<T> DataObjects { get; private set; }
        public BatchDataObjectEventArgs(IEnumerable<T> dataObjects)
        {
            this.DataObjects = dataObjects;
        }
    }
    delegate void BatchDataObjectSaved<T>(object sender, BatchDataObjectEventArgs<T> e);
