    static Predicate<Car> ByYear(int year)
    {
        return delegate(Car car)
        {
            return car.Year == year;
        };
    }
    static void Main(string[] args)
    {
        // yeah, this bit is C# 3.0, but ignore it - it's just setting up the list.
        List<Car> list = new List<Car>
        {
            new Car { Year = 1940 },
            new Car { Year = 1965 },
            new Car { Year = 1973 },
            new Car { Year = 1999 }
        };
        var car99 = list.Find(ByYear(1999));
        var car65 = list.Find(ByYear(1965));
        Console.WriteLine(car99.Year);
        Console.WriteLine(car65.Year);
    }
