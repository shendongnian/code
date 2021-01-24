    static void Main(string[] args)
    {
        var name = GetSatisfactoryAnswer("Could I get your name? (Press enter when you are done) ");
        var age = GetSatisfactoryAnswer("Awesome! Now if you could just enter your age: ");
        Console.WriteLine();
        Console.WriteLine("Name : {0}", name);
        Console.WriteLine("Age : {0}", age);
        Console.ReadLine();
    }
