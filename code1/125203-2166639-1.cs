    abstract class Item { public abstract decimal Cost(); }
    class Coffee : Item { public override decimal Cost() { return 1.99m; } }
    abstract class CoffeeDecorator : Coffee {
        protected Coffee _coffee;
        public CoffeeDecorator(Coffee coffee) { this._coffee = coffee; }
    }
    class Mocha : CoffeeDecorator {
        public Mocha(Coffee coffee) : base(coffee) { }
        public override decimal Cost() { return _coffee.Cost() + 2.79m; }
    }
    class CoffeeWithSugar : CoffeeDecorator {
        public CoffeeWithSugar(Coffee coffee) : base(coffee) { }
        public override decimal Cost() { return _coffee.Cost() + 0.50m; }
    }
