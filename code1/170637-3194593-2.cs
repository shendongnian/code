    var cars = CarsForSale.Where(c => c.RegNumber == 5);
    if(cars.Count() > 0)
    {
        foreach(Car car in cars)
            car.Color = "Red";
    }
    else
    {
        CarsForSale.Add(new Car(5, "Red"));
    }
    Save(CarsForSale);
