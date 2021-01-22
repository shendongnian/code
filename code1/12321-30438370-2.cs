    protected static string _Key = "";
        protected static string EncryptionKey
        {
            get
            {
                if (String.IsNullOrEmpty(_Key))
                {
                    _Key = ConfigurationManager.AppSettings["AESKey"].ToString();
                }
                return _Key;
            }
        }
