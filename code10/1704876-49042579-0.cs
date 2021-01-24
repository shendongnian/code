    public static void Main(string[] args)
    {
        Console.Write("Check to see if its a prime number!strong text Enter a number! ");
        string number = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(number))
        {
            Console.WriteLine("Input is empty.");
            return;
        }
        int Vo;
        bool success = int.TryParse(number, out Vo);
        if(!success)
        {
            Console.WriteLine("Input is not an integer.");
            return;
        }
        int Vo = Convert.ToInt32();
        int Va = Check_Prime(Vo);
         if (Va == 0)
         {
            Console.WriteLine("not a prime number!", Vo);
         }
        else
        {
            Console.WriteLine("Is a prime number!", Vo);
        }
        Console.Read();
    }
