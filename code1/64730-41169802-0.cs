    static void Main(string[] args)
    {
    //Randomize 15 numbers out of 25 - from 1 to 25 - in ascending order
    var randomNumbers = new List<int>();
    var randomGenerator = new Random();
    int initialCount = 1;
    for (int i = 1; i <= 15; i++)
    {
        while (initialCount <= 15)
        {
            int num = randomGenerator.Next(1, 26);
            if (!randomNumbers.Contains(num))
            {
                randomNumbers.Add(num);
                initialCount++;
            }
        }
    }
    randomNumbers.Sort();
    randomNumbers.ForEach(x => Console.WriteLine(x));
}
