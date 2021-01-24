    static void Main(string[] args)
    {
        string userName = "James";
        string[] userClass = new string[3] { "mage", "warrior", "assassin" };
        Console.WriteLine("What class will you be? You can choose from Mage, Warrior or Assassin:");
        string input = Console.ReadLine();
        if (input.ToLower() == userClass[0])
        {
            string Message = "You are a strong Willed Mage " + userName;
            Console.WriteLine(Message);
        }
        else if (input.ToLower() == userClass[1])
        {
            string Message = "Your are a valiant Warrior " + userName;
            Console.WriteLine(Message);
        }
        else if (input.ToLower() == userClass[2])
        {
            string Message = "You are a vigilant Assassin " + userName;
            Console.WriteLine(Message);
        }
        else
            Console.WriteLine("No proper class selected...");
        Console.ReadLine();
    }
