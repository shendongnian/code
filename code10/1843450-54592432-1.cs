    string a = "x²";
    var randomGenerator = new Random();
    int b = randomGenerator.Next(-50, 50);
    int c = randomGenerator.Next(-50, 50);
    Console.WriteLine("{0},{1},{2}", a, b, c);
    bool isRunning = true;
    while (isRunning)
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        if ((num1 + num2 == b) && (num1 * num2 == c))
        {
            Console.WriteLine("Correct.");
            isRunning = false;
        }
        else
        {
            Console.WriteLine("Wrong. Try again");
        }
    }
    Console.ReadLine();
