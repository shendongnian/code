    public class ConfigurationRepositoryImpl : IConfigurationRepository {
        #region attributes
        private static NameValueConfigurationCollection _connectionString;
        private static NameValueConfigurationCollection _values;
        #endregion
        public string GetConnectionString(string key) {
            string retVal = null;
            if (_connectionString == null ||
                _connectionString.Count == 0) {
                retVal = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            } else {
                retVal = _connectionString[key].Value;
            }
            return retVal;
        }
        public string GetValue(string key, string defaultValue) {
            string retVal = null;
            if (_values == null ||
                _values.Count == 0) {
                retVal = ConfigurationManager.AppSettings[key] ?? defaultValue;
            } else {
                retVal = _values[key].Value ?? defaultValue;
            }
            return retVal;
        }
        public static void ResetConnectionStrings() {
            _connectionString = null;
        }
        public static void ResetValues() {
            _values = null;
        }
        public static void SetConnecitonString(string key, string connectionString) {
            if (_connectionString == null) {
                _connectionString = new NameValueConfigurationCollection();
            }
            _connectionString.Add(new NameValueConfigurationElement(key, connectionString));
        }
        public static void SetValue(string name, string value) {
            if (_values == null) {
                _values = new NameValueConfigurationCollection();
            }
            _values.Add(new NameValueConfigurationElement(name, value));
        }
    }
