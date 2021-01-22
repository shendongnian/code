     public static class staticA 
    {
        /// <summary>
        /// Global variable storing important stuff.
        /// </summary>
        static string _importantData;
    
        /// <summary>
        /// Get or set the static important data.
        /// </summary>
        public static string ImportantData
        {
            get
            {
                return _importantData;
            }
            set
            {
                _importantData = value;
            }
        }
    }
