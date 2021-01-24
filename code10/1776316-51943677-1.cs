    public static void Main(String[] args)
    {
        Console.WriteLine("Enter number users:");
        int nbUsers = int.Parse(Console.ReadLine());
        storeDetails sd = new storeDetails();
        for(int i = 0 ; i < nbUsers ; i++)
        {
            Class1 tr = new Class1();        
            tr.getDetails();
            sd.store(tr);
        }
        Console.ReadLine();
    
    }
