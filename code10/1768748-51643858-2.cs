    static void Main(string[] args)
    {
        var RandomList = new List<Tuple<int, int>>();
        Random rnd = new Random();
        for (int i =0; i < 10; i++)
        {
            bool isUnique = false;
            do
            {
                int day = GetRandomDay(rnd);
                int period = GetRandomPeriod(rnd);
                if(RandomList.Where(x => x.Item1 == day && x.Item2 == period).FirstOrDefault() == null)
                {
                    RandomList.Add(new Tuple<int, int>(day, period));
                    isUnique = true;
                }
            } while (!isUnique);
        }
        Console.ReadLine();
    }
