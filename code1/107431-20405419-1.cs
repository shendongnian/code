      /// <summary>
        /// "Global variables" or kind of "Session State" class.
        /// To save a variable: ApplicationState.SetValue("currentCustomerName", "Jim Smith");
        /// To read a variable: MainText.Text = ApplicationState.GetValue<string>("currentCustomerName");
        /// </summary>
        public static class ApplicationData
        {
            /// <summary>
            /// Get an application-scope resource Formatted News
            /// </summary>
            /// <returns></returns>
            public static DataContainerModel GetNews()
            {
                var  formattedNews = (DataContainerModel)Application.Current.Resources["FormattedNews"];
                return formattedNews;
            }
    
            /// <summary>
            /// Set an application-scope resource Formatted News
            /// </summary>
            /// <param name="dataContainerModel"></param>
            public static void SetNews(DataContainerModel dataContainerModel)
            {
                Application.Current.Resources["FormattedNews"] = dataContainerModel;
            }
    
            private static ConcurrentDictionary<string, object> _values = new ConcurrentDictionary<string, object>();
          
            public static void SetValue(string key, object value)
            {
                if (_values.ContainsKey(key))
                {
                    var oldValue = new object();
                    _values.TryRemove(key, out oldValue);
                }
                _values.TryAdd(key, value);
            }
            
            public static T GetValue<T>(string key)
            {
                if (_values.ContainsKey(key))
                {
                    return (T)_values[key];
                }
                else
                {
                    return default(T);
                }
            }
    
        }
