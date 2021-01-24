    static void Main()
    {
        string ip = "127.0.0.1";
        
        string[] splitted = ip.Split('.');
        
        int value = 0;
        int factor = 1;
        
        for(int i=0;i<splitted.Length;i++)
        {
            value += factor*Convert.ToInt32(splitted[i]);
            factor*=256;
        }
        
        Console.WriteLine(value);
    }
