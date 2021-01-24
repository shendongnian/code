    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp9
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Dictionary<int,List<ISomething>> dictionary = new Dictionary<int, List<ISomething>>();
    
                var list = new List<Something>() {new Something()};
    
                    dictionary.Add(1,list.ToList<ISomething>());
    
               
            }
            public interface ISomething
            {
                
                
            }
    
            public class Something : ISomething
            {
    
            }
        }
    }
