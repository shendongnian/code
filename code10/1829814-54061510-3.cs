     static void Main(string[] args)
        {
            Program.ShowHeader("Visitor Pattern");
    
            List<Product> products = new List<Product>
            { 
                new Book(200),new Book(205),new Book(303),new Wine(706)
            };
    
            ShowTitle("Basic Price calculation");
            BasicPriceVisitor pricevisitor = new BasicPriceVisitor();
            products.ForEach(x =>
            {
                x.Accept(pricevisitor);
            });
    
            Console.WriteLine("");
        }     
 
