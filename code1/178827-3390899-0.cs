        public T GetValue<T>(string fieldName, T @default, object valueMap, Converter<string, T> parse)
        {
            T value;
            string literalString = null; // read string from file
    
            if (string.IsNullOrEmpty(literalString))
                return @default;
            else
            {
                var map = ToDictionary<T>(valueMap);
                // attempt to look up the corresponding value associated with literalString
                if (map.TryGetValue(literalString, out value))
                    return value;
                else
                    // literalString does not match any value in the value map,
                    // so parse it using the provided delegate
                    return parse(literalString);
            }
        }
    
        public static Dictionary<string, T> ToDictionary<T>(object valueMap)
        {
            // Use reflection to read public properties and add them as keys to a
            // dictionary along with their corresponding value
            // The generic parameter enforces that all properties
            // must be of the specified type,
            // otherwise the code here can throw an exception or ignore the property
            throw new NotImplementedException();
        }
            // usage
            int field1 = myObject.GetValue("Field1", 0, new { one = 1, two = 2, TheAnswer = 42, min = int.MinValue, max = int.MaxValue, INF = int.MaxValue }, int.Parse);
            double field2 = myObject.GetValue("Field2", 0.0, new { PI = Math.PI, min = double.MinValue, max = double.MaxValue }, double.Parse);
