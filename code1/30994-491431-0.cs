    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Delegates
    {
        class Program
        {
            static void Main(string[] args)
            {
                Collection coll = new Collection(5);
                coll[0] = "This";
                coll[1] = "is";
                coll[2] = "a";
                coll[3] = "test";
    
                var result = coll.Find(x => x == "is");
    
                Console.WriteLine(result);
    
                result = coll.Find(x => x.StartsWith("te"));
    
                Console.WriteLine(result);
    
        }
    
    }
    
    public class Collection
    {
        string[] _Items;
    
        public delegate bool FindDelegate(string FindParam);
    
        public Collection(int Size)
        {
            _Items = new string[Size];
         
        }
    
        public string this[int i]
        {
            get { return _Items[i]; }
            set { _Items[i] = value; }
        }
    
        public string Find(FindDelegate findDelegate)
        {
            foreach (string s in _Items)
            {
                if (findDelegate(s))
                    return s;
            }
            return null;
        }
    
    }
    }
