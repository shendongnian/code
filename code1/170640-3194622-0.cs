    var matches = CarsForSale.Where(c => c.RegNumber == 5);
    int numMatches = 0;
    
    foreach (Car match in matches )
    {
        match.Color = "Red";
        ++numMatches;
    }
    if (numMatches == 0)
    {
       CarsForSale.Add(new Car(5, "Red"));
    }
