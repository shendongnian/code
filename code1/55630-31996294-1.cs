        public static bool IsComplex(Type typeIn)
        {
            if(typeIn.IsEnum)
            {
                return true;
            }
            if (typeIn.IsSubclassOf(typeof(System.ValueType)) || typeIn.Equals(typeof(string))) //|| typeIn.IsPrimitive
                return false;
            else
                return true;
        }
