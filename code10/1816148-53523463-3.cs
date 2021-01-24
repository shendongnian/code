    public class DataLoader {
        
        #region Fields
    
        private bool loading = true;
        private Thread loadingThread;
        private SynchronizationContext loadingContext;
    
        #endregion
    
        #region Properties
    
        public float Progress { get; private set; } = 0f;
    
        #endregion
    
        #region Events
    
        public event EventHandler ObjectLoaded;
        private void OnObjectLoaded() => loadingContext.Post(new SendOrPostCallback(PostObjectLoaded), new EventArgs());
        private void PostObjectLoaded(object data) => ObjectLoaded?.Invoke(this, (EventArgs)data);
    
        #endregion
    
        #region Constructor(s)
    
        public DataLoader() {
            if (SynchronizationContext.Current != null)
                loadingContext = SynchronizationContext.Current;
            else
                loadingContext = new SynchronizationContext();
    
            loadingThread = new Thread(new ThreadStart(LoadData));
            loadingThread.IsBackground = true;
            loadingThread.Start();
        }
    
        #endregion
        
    
        #region Private Methods
    
        private void LoadData() {
            while (loading) {
                // Do some cool stuff to load data.
                CoolStuff();
    
                // Increment progress.
                Progress += 0.01f;
                if (Progress >= 1.0f)
                    loading = false;
    
                // Now this object is loaded, raise event for subscribers.
                OnObjectLoaded();
            }
        }
        private void CoolStuff() {
            // Do cool loading stuff.
        }
    
        #endregion
    
    }
