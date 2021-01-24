    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Program {
        public static void Main() {
            var hashSet = new HashSet<List<double>>(new ListComparer());
            
            hashSet.Add(new List<double> { 1.2d, 1.5d });
            hashSet.Add(new List<double> { 1.2d, 1.5d });
            
            Console.Write(hashSet.Count);
        }
    
        public class ListComparer : IEqualityComparer<List<double>> 
    	
        {
            public bool Equals(List<double> x, List<double> y)
            {
                // your logic for equality
                return true;
            }
    
            public int GetHashCode(List<double> obj)
            {
               int hash = 0;
               unchecked {
                   foreach(var d in obj) {
                       hash += d.GetHashCode();
                   }
               }
               return hash;
            }  
    	}
    }
