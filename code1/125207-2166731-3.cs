    // NOTE: implement IDecoratedExpressing for all decorations to provide a handle. 
    // Example of first:
    class Mocha : CoffeeDecorator, IDecoratedExpressing 
    {
        Item decoratedItem;
        // express inner
        public IDecoratedExpressing InnerDecorated {
            get {return decoratedItem;}
        }
        public Mocha(Coffee coffee)
        {
           decoratedItem = coffee;
        }
    }
