    var rand = new Random();
    string a = "x²";
    int num1 = rand.Next(-50, 50);
    int num2 = rand.Next(-50, 50);
    int b = num1 + num2;
    int c = num1 * num2;
    Console.WriteLine($"{a}, {b}, {c}");
    while (true)
    {
        int guess1 = int.Parse(Console.ReadLine());
        int guess2 = int.Parse(Console.ReadLine());
        if (guess1 == num1 && guess2 == num2)
        {
            break;
        }
        Console.WriteLine("Wrong. Try again");
    }
    Console.WriteLine("Correct.");
