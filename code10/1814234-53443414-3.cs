    namespace DeliAndPizza
    {
        class Toppings
        {
            bool[] ToppingList;
            string[] ToppingNames;
            double[] ToppingPrices;
    
            public Toppings(): this(12) {} //default length is 12
            public Toppings(int length)
            {
                ToppingList = new bool[length];
                ToppingNames = new string[length];
                ToppingPrices = new double[length];
            }
    
            public Toppings(bool[] list, string[] name, double[] price)
            {
                this.ToppingList = list;
                this.ToppingNames = name;
                this.ToppingPrices = price;
            }
        }
    }
