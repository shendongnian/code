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
