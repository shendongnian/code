    /// <summary>
    /// A singleton class to keep your application data
    /// </summary>
    public class MySharedData
    {
        /// <summary>
        /// Called when data changes
        /// </summary>
        public event EventHandler DataChanged;
        private static MySharedData _instance;
        private object _data;
        public static MySharedData Instance => _instance ?? (_instance = new MySharedData());
        private MySharedData()
        {
        }
        /// <summary>
        /// Gets or sets the data you want to share
        /// </summary>
        public object Data
        {
            get => _data;
            set
            {
                _data = value;
                OnDataChanged();
            }
        }
        protected virtual void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
