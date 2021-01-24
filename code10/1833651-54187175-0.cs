    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            public class Salesman
            {
                public string Name { get; set; }
                public int District { get; set; }
                public int ArticlesSold { get; set; }
            }
    
            static void Main(string[] args)
            {
    
                var salesmen = new Salesman[] {
                     // Fill collection by some means...
                };
    
                // Then for example:
                // sort by Ascending sales count
                var sorted = salesmen.OrderBy(x => x.ArticlesSold);
    
                // or descending
                sorted = salesmen.OrderByDescending(x => x.ArticlesSold);
    
                // or by something more complex
                sorted = salesmen.OrderBy(x => x.ArticlesSold).ThenBy(x => x.District);
            }
    
        }
    }
