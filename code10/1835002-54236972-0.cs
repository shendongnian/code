        private static ViewModel _createInstance = null;
        
        public static ViewModel CreateInstance
        {
            get
            {
                if (null == _createInstance)
                {
                    _createInstance = new ViewModel();
                }
                return _createInstance;
            }
        }//END CreateInstance
