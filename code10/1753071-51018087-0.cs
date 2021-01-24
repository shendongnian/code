     class Hello 
    {
       public void SituationSecondOne()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Choices:");
        Console.WriteLine("1: First");
        Console.WriteLine("2: Second");
        Console.WriteLine(" ");
        int ChoiceOne = Convert.ToInt32(Console.ReadLine());
        switch (ChoiceOne)
        {
            case (1):
                Console.WriteLine("TEST2");
                break;
            case (2):
                Console.WriteLine("TEST2");
                break;
            case (1337):
                Console.WriteLine(" ");
                Console.WriteLine("Thank you for playing");
                Console.ReadLine();
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine(" ");
                Console.WriteLine("Now, let's try that again ... (¬_¬)");
                SituationSecondOne();
                break;
        }
    }
        static void Main() 
        {
            SecondSet s2 = new SecondSet();
            Console.ReadKey();
        }
    }
