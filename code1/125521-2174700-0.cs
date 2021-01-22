    using System;
    using System.Collections.Generic;
    
    namespace Records
    {
        public class BaseRecord
        {
            public bool isDirty;
            public object[] itemArray;
    
            public static Dictionary<Type, string[]> columnNames = new Dictionary<Type, string[]>();
        }
    
        public class PeopleRec : BaseRecord
        {
            static PeopleRec()
            {
                string[] names = new string[2];
                names[0] = "FIRST_NAME";
                names[1] = "LAST_NAME";
                BaseRecord.columnNames[typeof(PeopleRec)] = names;
            }
        }
    
        public class DoWork<T> where T : BaseRecord
        {
            public void DisplayColumnNames()
            {
                foreach (string s in BaseRecord.columnNames[typeof(T)])
                    Console.WriteLine("{0}", s);
            }
    
            public void DisplayItem(T t)
            {
                for (int i = 0; i < t.itemArray.Length; i++)
                {
                    Console.WriteLine("{0}: {1}", BaseRecord.columnNames[typeof(T)][i], t.itemArray[i]);
                }
            }
        }
    
        class Program
        {
            public static void Main()
            {
                PeopleRec p = new PeopleRec
                {
                    itemArray = new object[] { "Joe", "Random" }
                };
    
                DoWork<PeopleRec> w = new DoWork<PeopleRec>();
                w.DisplayColumnNames();
                w.DisplayItem(p);
            }
        }
    }
