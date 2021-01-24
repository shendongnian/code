    using System.Collections.Generic;
    using System.Linq; // Ensure to have this at the top of your source to access Linq methods.
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>();
                // Fill list here...
                // Use Linq Max and Min functions.
                // You pass the property to calculate the minimum and maximum from 
                // as x => x.Price (where x would represent an Item currently being
                // compared against another by Linq behind the scenes).
                decimal highestPrice = items.Max(x => x.Price);
                decimal lowestPrice = items.Min(x => x.Price);
            }
        }
        public class Item
        {
            public decimal Price { get; set; }
            public string Description { get; set; }
        }
    }
