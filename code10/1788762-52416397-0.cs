    class Car
    {    
        public Person Owner { get; set; } 
        public string Name {get; set;}   
    }
    Car mercedes = new Car {Name = "Mercedes"};
    John.AddCar(mercedes);
    John.AddCar(new Car { Name = "Prado" });
    foreach (Car car in John.Cars)
    {
         Console.WriteLine(car.Name);   // not working
    }
       
 
