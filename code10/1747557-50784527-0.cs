    public static Random randd = new Random();
    public static void FlachCards()
    {
    Start:
        if (AskAUser() == "Y")
        {
            goto Start;
        }
            
    }
    public static String AskAUser()
    {
        Console.WriteLine("Enter Y to play again");
        return Console.ReadLine();
    }
