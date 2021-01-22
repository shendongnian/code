    public static class RequestScopedData
    {
        private const string key = "key_that_you_choose";
        public static bool IsSaving
        {
            get
            {
                object o = HttpContext.Current.Items[key];
                return Convert.ToBoolean(o);            
            }
            set
            {
                HttpContext.Current.Items[key] = value;
            }
        }
    }
