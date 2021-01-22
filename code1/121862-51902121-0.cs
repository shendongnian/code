    public class MainVm
    {
        private ObservableCollection<MiniVm> _collectionOfObjects;
        private readonly object _collectionOfObjectsSync = new object();
        public MainVm()
        {
           
            _collectionOfObjects = new ObservableCollection<MiniVm>();
            // Collection Sync should be enabled from the UI thread. Rest of the collection access can be done on any thread
            Application.Current.Dispatcher.BeginInvoke(new Action(() => 
            { BindingOperations.EnableCollectionSynchronization(_collectionOfObjects, _collectionOfObjectsSync); }));
        }
        /// <summary>
        /// A different thread can access the collection through this method
        /// </summary>
        /// <param name="newMiniVm">The new mini vm to add to observable collection</param>
        private void AddMiniVm(MiniVm newMiniVm)
        {
            lock (_collectionOfObjectsSync)
            {
                _collectionOfObjects.Insert(0, newMiniVm);
            }
        }
    }
