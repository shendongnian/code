    using System;
    using System.Collections.Specialized;
    using System.Data.Common;
    public static class Program
    {
        static void Main()
        {
            StringDictionary lookup = new StringDictionary();
            lookup.Add("abc", "def");
            lookup.Add("ghi", "jkl");
    
            string foo = Serialize(lookup);
            Console.WriteLine(foo);
    
            StringDictionary bar = Deserialize(foo);
            foreach (string key in bar.Keys)
            {
                Console.WriteLine("{0}={1}", key, bar[key]);
            }
        }
        public static string Serialize(StringDictionary data)
        {
            if(data == null) return null; // GIGO
            DbConnectionStringBuilder db = new DbConnectionStringBuilder();
            foreach (string key in data.Keys)
            {
                db[key] = data[key];
            }
            return db.ConnectionString;
        }
        public static StringDictionary Deserialize(string data)
        {
            if (data == null) return null; // GIGO
            DbConnectionStringBuilder db = new DbConnectionStringBuilder();
            StringDictionary lookup = new StringDictionary();
            db.ConnectionString = data;
            foreach (string key in db.Keys)
            {
                lookup[key] = Convert.ToString(db[key]);
            }
            return lookup;
        }
        
    }
