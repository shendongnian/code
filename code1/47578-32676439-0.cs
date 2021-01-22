        public string value1 { get; set; }
        public string value2 { get; set; }
        public PropertyInfo[] GetProperties()
        {
            try
            {
                return this.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public PropertyInfo GetByParameterName(string ParameterName)
        {
            try
            {
                return this.GetType().GetProperties().FirstOrDefault(x => x.Name == ParameterName);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static MyObject SetValue(MyObject obj, string parameterName,object parameterValue)
        {
            try
            {
                
                obj.GetType().GetProperties().FirstOrDefault(x => x.Name == parameterName).SetValue(obj, parameterValue);
                return obj;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
