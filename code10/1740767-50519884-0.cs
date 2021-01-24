    static Random _random = new Random();
    public static void Shuffle<T>(IList<T> items)
    {
        for (int i = thisList.Count - 1; i >= 0; i--)
        {
            int j = RandomNumberGenerator.Next(0, i);
            T tmp = items[i];
            items[i] = items[j];
            items[j] = tmp;
        }
    }
 
    var numbers = Enumerable.Range(1,99).ToList();
    Shuffle(numbers);
    foreach (var number in numbers)
    {
         Console.WriteLine(number);
    }
