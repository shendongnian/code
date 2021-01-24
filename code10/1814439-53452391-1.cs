    using System.Collections.Generic;
    using K = System.Collections.Generic.KeyValuePair<string, string>; // $$$
    public class MainClass
    {
        public static void Main(string[] args)
        {
            DBClass db;
            db = new DBClass();
            db.Insert("personen", new List<K> {  // $$$
                new K("firstname", "Dominic")    // $$$
            });
        }
    }
    public class DBClass
    {
        public void Insert(string name, List<KeyValuePair<string, string>> values)
        {
            // ...
        }
    }
