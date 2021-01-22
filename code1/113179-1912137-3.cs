    using System.Linq;
    
    public Car[] Filter(Car[] input)
    {
        return input.Where(c => c.IsAvailable).ToArray();
    }
