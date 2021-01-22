        private System.Threading.SynchronizationContext mContext = null;
        /// <summary>
        /// Constructor for MyBackgroundWorkerClass
        /// </summary>
        public MyBackgroundWorkerClass(System.Threading.SynchronizationContext context)
        {
            mContext = context;
        }
