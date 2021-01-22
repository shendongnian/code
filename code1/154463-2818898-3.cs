    private static Random random = new Random((int)DateTime.Now.Ticks);
    private static string RandomString(int min, int max)
    {
        string str = "";
        int size = random.Next(min, max + 1);
        for (int i = 0; i < size; i++)
            str += Convert.ToChar(Convert.ToInt32(
                           Math.Floor(26 * random.NextDouble() + 65)));
        return str;
    }
    public static void MeassureTicks(int numberCars, int minLength, int maxLength)
    {
        // Generate random list
        List<Car> cars = Enumerable.Range(0, numberCars)
                         .Select(x => new Car(RandomString(
                                 minLength, maxLength))).ToList();
        Stopwatch sw1 = new Stopwatch(), sw2 = new Stopwatch(),
                  sw3 = new Stopwatch(), sw4 = new Stopwatch();
        sw1.Start();
        string concat1 = CreateConcatenatedList(cars);
        sw1.Stop();
        sw2.Start();
        string concat2 = String.Join(",", cars.Select(c => c.Name).ToArray());
        sw2.Stop();
        sw3.Start();
        if (numberCars <= 5000)
        {
            string concat3 = cars.Select(c => c.Name).Aggregate("",
                    (str, current) =>
                    {
                        return str.Length == 0 ? str = current :
                               str += "," + current;
                    }).ToString();
        }
        sw3.Stop();
        sw4.Start();
        string concat4 = cars.Select(c => c.Name).Aggregate(
                new StringBuilder(), (sb, current) =>
                {
                    return sb.Length == 0 ? sb.Append(current) :
                           sb.AppendFormat(",{0}", current);
                }).ToString();
        sw4.Stop();
        Console.WriteLine(string.Format("{0} car strings joined:\n" +
                    "\tYour method:                  {1} ticks\n" + 
                    "\tLinq+String.Join:             {2} ticks\n" + 
                    "\tLinq+Aggregate+String.Concat: {3} ticks\n" + 
                    "\tLinq+Aggregate+StringBuilder: {4} ticks\n",
                    cars.Count, sw1.ElapsedTicks, sw2.ElapsedTicks, 
                    numberCars <= 5000 ? sw3.ElapsedTicks.ToString() : "-", 
                    sw4.ElapsedTicks));
