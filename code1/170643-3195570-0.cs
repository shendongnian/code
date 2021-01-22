    var carsForSale = new Dictionary<int, Car>();
    //Create a car which you like to check
    var checkCar = new Car(4, Color.Red);
    //Use this approach if you want to change only a few properties
    //of an existing item
    if (carsForSale.ContainsKey(checkCar.RegNum))
    {
        carsForSale[checkCar.RegNum].Color = checkCar.Color;
    }
    else
    {
        carsForSale[4] = checkCar;
    }
    //If you have to take over ALL property settings, you can also
    //forget the old item and take the new one.
    //The index operator is smart enough to just add a new one
    //or to delete an old and add the new in one step.
    carsForSale[checkCar.RegNum] = checkCar;
