    static event Func<NewProductArgs, string> ProductAddedEvent;
            static void Main(string[] args)
            {
                ProductAddedEvent += Program_ProductAddedEvent;
    
                var d = ProductAddedEvent?.GetInvocationList().FirstOrDefault();
    
                var r = d.DynamicInvoke();
            }
    
            private static string Program_ProductAddedEvent(NewProductArgs arg)
            {
                return $"{args.Product.name} {args.Product.Price}";
            }
