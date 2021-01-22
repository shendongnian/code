    var cars = CarsForSale.Where(c => c.RegNumber == 5);
    if(cars.Any())
    {
        foreach(Car car in cars)
            car.Color = "Red";
    }
    else
    {
        CarsForSale.Add(new Car(5, "Red"));
    }
    Save(CarsForSale);
