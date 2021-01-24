    static void Main(string[] args)
    {
        int userInput;
        CarsSold[] days = new CarsSold[7]; // create an array with 7 items
        int x;
        for (x = 0; x < days.Length; x++)
        {
            Console.Write("Enter the number of cars sold: ");
            bool ifInt = int.TryParse(Console.ReadLine(), out userInput);
            days[x] = new CarsSold(userInput); // assign a value to the days array at position x.
        }
    }
