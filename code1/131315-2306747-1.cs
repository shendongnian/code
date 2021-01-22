    int i = 0;
    Console.WriteLine("Enter a number");
    int.TryParse(Console.ReadLine(),out i);
    while (i < 1 || i > 10)
    {
        Console.WriteLine("Try Again");
        int.TryParse(Console.ReadLine(),out i);
    }
:)
