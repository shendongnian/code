    static void Main(string[] args)
            {
                List<Car> cars = new List<Car>();
                SUV suv = new SUV { name = "mySuv", year = 2010 };
                cars.Add(suv);
    
                SUV anotherSuvReference = (SUV)cars[0];
                Console.WriteLine(anotherSuvReference.name);
            }
    
            class Car
            {
                public string name;
                public int year;
            }
            class SUV : Car
            {
            }
