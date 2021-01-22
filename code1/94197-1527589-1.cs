    public static class MyTools
    {
        public static TReturn GetValue<TReturn>(this object input, 
                                                string propertyName)
        {
            if (input == null)
                return default(TReturn);
            var pi = input.GetType().GetProperty(propertyName);
            if (pi == null)
                return default(TReturn);
            var val = pi.GetValue(input, null);
            return (TReturn)(val == null ? default(TReturn) : val);
        }
        public static string GetString(this object input, string propertyName)
        {
            return input.GetValue<string>(propertyName);
        }
        public static List<SimpleAddress> GetAddress(this MyObject input)
        {
            return (
                from i in Enumerable.Range(1, 2)
                let address = input.GetString("Address" + i.ToString())
                let name = input.GetString("Address" + i.ToString() + "Name")
                let desc = input.GetString("Address" + i.ToString() + "Desc")
                select new SimpleAddress() { Address = address, 
                                             Name = name, 
                                             Description = desc }
               ).ToList();
        }
    }
