    bool answeredCorrectly = false;
    while (!answeredCorrectly)
    {
        if ((x % 7 == 0) && (x % 12 == 0))
        {
            Console.WriteLine("well done, " + x + " can be divided by 7 and 12");
            answeredCorrectly = true; // This will have us exit the while loop
        }
        else
        {
            Console.WriteLine("Wrong, try again.");
            x = int.Parse(Console.ReadLine());
        }
    }
