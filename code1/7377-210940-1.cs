    using System.Collections.Generic;
    
    namespace ReplaceWithSpace 
     {
        class Program 
        {
            static void Main(string[] args) 
            {
                string someString = "#1, 1+1=2 $string$!";
     
                var charsToRemove = new List<char>(@"!@#$%^*_+=\");
                charsToRemove.ForEach(c => someString = someString.Replace(c, ' '));
                
                System.Diagnostics.Debug.Print(someString); //" 1, 1 1 2  string  "
            }
        }
    }
