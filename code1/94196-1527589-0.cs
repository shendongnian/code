    public static class MyTools
    {
        public static string GetString(this object input, string propertyName)
        {
            if (input == null)
                return null;
            var pi = input.GetType().GetProperty(propertyName);
            if (pi == null)
                return null;
            return pi.GetValue(input, null) as string;
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
