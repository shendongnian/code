        public T? ParseValue<T>(string value) where T : struct
        {
            if (typeof(T) == typeof(int))
            {
                int i;
                if (int.TryParse(value, out i))
                    return (T)(object)i;
                return null;
            }
            if (typeof(T) == typeof(decimal)) 
            {
                decimal d;
                if (decimal.TryParse(value, out d))
                    return (T)(object)d;
                return null;
            }
            // other supported types...
            throw new ArgumentException("Type not supported");
        }
