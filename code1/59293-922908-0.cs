    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace array
    {
        class Program
        {
            static object Index(object [] array, int idx)
            {
                if (idx >= array.Length)
                    return null;
                else
                    return array[idx];
            }
            static void Main(string[] args)
            {
                object[] blah = new object[10];
                object o = Index(blah, 10);
            }
        }
    }
