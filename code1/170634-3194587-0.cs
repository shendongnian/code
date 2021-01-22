    Car car = CarsForSale.Find(c => c.RegNumber == 5);
    if (car != null)
    {
       car.Color = "Red";
    }
    else
    {
       CarsForSale.Add(new Car(5, "Red"));
    }
    Save(CarsForSale);
