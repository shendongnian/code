    // Not the most performant implementation, but should be easy to understand.
    // I'll let you perform any performance optimisations based on your needs.
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
