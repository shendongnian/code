    private static Random random = new Random((int)DateTime.Now.Ticks);
    private static string RandomString(int size)
    {
        string str = "";
        for (int i = 0; i < size; i++)
            str += Convert.ToChar(Convert.ToInt32(
                                  Math.Floor(26 * random.NextDouble() + 65)));
        return str;
    }
    private static void MeassureTicks(int numberCars)
    {
        // Generate random list
        List<Car> cars = Enumerable.Range(0, numberCars)
                         .Select(x => new Car(RandomString(30))).ToList();
        Stopwatch sw1 = new Stopwatch(), sw2 = new Stopwatch();
        sw1.Start();
        string concat1 = CreateConcatenatedList(cars);
        sw1.Stop();
        sw2.Start();
        string concat2 = String.Join(",", cars.Select(c => c.Name).ToArray());
        sw2.Stop();
        Console.WriteLine(string.Format("{0} car strings joined. " + 
                    "Your method: {1} ticks; Linq: {2} ticks", 
                    cars.Count, sw1.ElapsedTicks, sw2.ElapsedTicks));
    }
