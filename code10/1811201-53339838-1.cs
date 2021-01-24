    /// <summary>
    /// Code for https://stackoverflow.com/q/53321654/380384
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var all = new List<Product>();
            all.Add(new Product(1, "TID", 13.2m));
            all.Add(new Product(2, "TJQ", 11.8m));
            all.Add(new Product(3, "UIZ", 15.7m));
            string description = "4 - UYA - 18.4";
            all.Add(Product.Parse(description));
            foreach(Product item in all)
            {
                Console.WriteLine(item);
            }
            //1 - TID - 13.2
            //2 - TJQ - 11.8
            //3 - UIZ - 15.7
            //4 - UYA - 18.4
            if(all[3].ToString().Equals(description))
            {
                Console.WriteLine(@"Product -> String is ok.");
            }
            if(Product.Parse(description).Equals(all[3]))
            {
                Console.Write(@"String -> Product is ok.");
            }
        }
    }
