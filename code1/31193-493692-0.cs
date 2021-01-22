    foreach(Car c in listOfCars)
    {
        if (foundColors.containsKey(c.Color))
        {
            carsToDelete.Add(c);
        }
        else
        {
            foundColors.Add(c.Color, c);
        }
    }
