        private static OrderCompletion instance;
        /// <summary>
        /// Get the single instance of the object
        /// </summary>
        public static OrderCompletion Instance
        {
            get
            {
                lock (typeof(OrderCompletion))
                {
                    if (instance == null)
                        instance = new OrderCompletion();
                }
                return instance;
            }
        }
