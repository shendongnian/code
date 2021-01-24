    static void Main(string[] args)
    {
        int incrementingNumber = 0;
        
        while(true)
        {
            Increment(ref incrementingNumber, out incrementingNumber);
        
            Console.WriteLine(incrementingNumber);
            Thread.Sleep(1000);
        }
    }
    private static void Increment(ref int inNumber ,out int outNumber)
    {
        outNumber = inNumber + 46;
    }
