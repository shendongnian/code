    static void Main(string[] args)
    {
        int result = 0;
        Console.WriteLine("Give me a number over 5 bro");
        int x = int.Parse(Console.ReadLine());
        try{
           result = AddNumbers(x, 5);
           Console.WriteLine(result);
        }catch(Exception e)
        {
           Console.WriteLine(e.Message);
        }
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();
    }    
    public static int AddNumbers(int number1, int number2)
    {
        int result = number1 + number2;
        if (result > 10)
        {
            return result;
        }
        else throw new Exception("brah I've told ya that I want more than 5");
    }
