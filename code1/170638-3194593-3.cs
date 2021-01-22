    Car car = CarsForSale.Where(c => c.RegNumber == 5).FirstOrDefault();
    
    if(car != null)
    {
        car.Color = "Red";
    }
    else
    {
        CarsForSale.Add(new Car(5, "Red"));
    }
    
    Save(CarsForSale);
