    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>();
                // Fill list here.
                decimal highestPrice = items.Max(x => x.Price);
                decimal lowestPrice = items.Min(x => x.Price);
            }
        }
    }
