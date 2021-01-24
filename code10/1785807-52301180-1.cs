    static void Main (string[] args)
    {
        int n;
        do {
            Console.Write ("Enter an integer : ");
        } while(!int.TryParse(Console.ReadLine (), out n));
        //int has been entered, now do something else...
    }
