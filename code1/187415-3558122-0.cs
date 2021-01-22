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
        public BatchToken BeginSave()
        {
            BatchToken token = new BatchToken();
            _BatchSavedDataObjects.Add(token, new List<T>());
            return token;
        }
        public void EndSave(BatchToken token)
        {
            this.OnBatchSaved(token); // this causes a single BatchSaved event to be fired
            if (!_BatchSavedDataObjects.Remove(token))
                throw new ArgumentException("The BatchToken is expired or invalid.", "token");
        }
        public void Save(BatchToken token, T dataObject)
        {
            List<T> batchSavedDataObjects;
            if (_BatchSavedDataObjects.TryGetValue(token, out batchSavedDataObjects))
            {
                // perform save logic
                batchSavedDataObjects.Add(dataObject);
            }
            else
            {
                throw new ArgumentException("The BatchToken is expired or invalid.", "token");
            }
        }
        public event BatchDataObjectSaved<T> BatchSaved;
        protected void OnBatchSaved(BatchToken token)
        {
            if (this.BatchSaved != null)
            {
                List<T> batchSavedDataObjects;
                if (_BatchSavedDataObjects.TryGetValue(token, out batchSavedDataObjects))
                {
                    this.BatchSaved(this, new BatchDataObjectEventArgs<T>(batchSavedDataObjects));
                }
                else
                {
                    throw new ArgumentException("The BatchToken is expired or invalid.", "token");
                }
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
