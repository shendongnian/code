        public class Car
        {
            public static Car RedExpensiveCar = new Car("Red", 250000);
            public Car()
            {
    
            }
    
            public Car(string color, int price)
            {
                Color = color;
                Price = price;
            }
    
            public string Color { get; set; }
            public int Price { get; set; }
        }
