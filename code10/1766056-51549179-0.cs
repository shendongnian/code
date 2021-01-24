    static void Main(string[] args)
    {
        List<Color> ColorList = new List<Color>() { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink };
        Shuffle(ColorList);
        while (ColorList.Count > 0)
        {
            Console.WriteLine(ColorList[0]);    // Equivalent of using the color.
            ColorList.RemoveAt(0);              // Remove from the list once used.
        }
        Console.ReadLine();
    }
    static void Shuffle<T>(IList<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
