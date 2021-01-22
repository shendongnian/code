    public Car[] Filter(Car[] input)
    {
        List<Car> availableCars = new List<Car>();
        foreach(Car c in input)
        {
            if(c.IsAvailable)
                availableCars.Add(c);
        }
        return availableCars.ToArray();
    }
