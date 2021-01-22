    public static void Main()
    {
        List<Cars> cars = new List<Cars>();
        List<Animals> animals = new List<Animals>();
        cars.Add(Cars.Chevrolet);
        cars.Add(Cars.Honda);
        cars.Add(Cars.Toyota);
        foreach (Cars value in cars)
        {
            // This time the cast is explicit.
            Animals isItACar = (Animals) value;
            Console.WriteLine(isItACar.ToString());
        }
        Console.ReadLine();
    }
