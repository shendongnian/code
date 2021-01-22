    using System;
    using System.Collections;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ArrayList a = new ArrayList();
                a.Add("1");
                a.Add("13");
                a.Add("3");
                a.Add("25");
                a.Add("2");
                a.Add("12");
                a.Sort(new CustomComparer());
    
                foreach (String s in a)
                    Console.WriteLine(s);
    
                Console.Read();
            }
    
    
        }
    
        public class CustomComparer : IComparer
        {
            Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);
    
            public int Compare(object x, object y)
            {
                // Convert string comparisons to int
                return _comparer.Compare(Convert.ToInt32(x), Convert.ToInt32(y));
            }
        }
    }
