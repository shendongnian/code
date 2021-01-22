    public static class EnumHelper<T>
    {
        public static bool IsValidValue(int value)
        {
            try
            {
                Parse(value.ToString());
            }
            catch
            {
                return false;
            }
    
            return true;
        }
        public static T Parse(string value)
        {
            var values = GetValues();
            int valueAsInt;
            var isInteger = Int32.TryParse(value, out valueAsInt);
            if(!values.Select(v => v.ToString()).Contains(value)
                && (!isInteger || !values.Select(v => Convert.ToInt32(v)).Contains(valueAsInt)))
            {
                throw new ArgumentException("Value '" + value + "' is not a valid value for " + typeof(T));
            }
    
            return (T)Enum.Parse(typeof(T), value);
        }
    
        public static bool TryParse(string value, out T p)
        {
            try
            {
                p = Parse(value);
                return true;
            }
            catch (Exception)
            {
                p = default(T);
                return false;
            }
            
        }
    
        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof (T)).Cast<T>();
        }
    }
