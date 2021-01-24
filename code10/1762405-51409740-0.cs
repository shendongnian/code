    static void Main(string[] args)
    {
        // generate random number from 1 to 5
        int i = NumberGenerator.RandomNumberGenerator(5, 1);
        // print the number
        Console.WriteLine(i);
        // set j equal to (1 to 5) - 7 + 1 = (-6 to -1) [but this line is unused]
        int j = i - Data.ElementList.Count + 1;
        // Get an element in position -6 to -1
        Element y = NumberGenerator.RandomElementGenerator(j);
        // Wait for user to press a key
        Console.ReadKey();
    }
