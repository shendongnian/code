    static void Main (string[] args)
    {
        int n= 0;
        bool b;
        do {
            Console.Write ("Enter an integer : ");
            b = int.TryParse(Console.ReadLine (), out n);
        } while(!b);
        //int has been entered, now do something else...
    }
