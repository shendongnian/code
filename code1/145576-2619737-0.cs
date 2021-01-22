    [ Conditional("DEBUG") ]
    public static void LogLine(string msg,string detail)
    {
        Console.WriteLine("Log: {0} = {1}",msg,detail);
    }
 
    public static void Main(string[] args)
    {
        int Total = 0;
        for(int Lp = 1; Lp < 10; Lp++)
        {
            LogLine("Total",Total.ToString());
            Total = Total + Lp;
        }
    }
