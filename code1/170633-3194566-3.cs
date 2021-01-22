    var cars = CarsForSale.Where(c => c.RegNumber == 5);
    foreach (Car car in cars)
    {
        car.Color = "Red";
    }
    if (!car.Any())
    {
        CarsForSale.Add(new Car(5, "Red"));
    }
