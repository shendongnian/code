    using System.Collections.Generic;
    public class MainClass
    {
        public static void Main(string[] args)
        {
            DBClass db;
            db = new DBClass();
            db.Insert("personen",
                "firstname", "Dominic",
                "lastname", "Cinimod"
            );
        }
    }
    public class DBClass
    {
        public void Insert(string name, params string[] values)
        {
            if (values.Length % 2 == 1)
            {
                throw new System.ArgumentException("wrong number of arguments");
            }
            // ...
        }
    }
