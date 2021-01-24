    decimal Num1 = 0.0m;
    decimal Num2 = 2.2m;
        
    char Op = 'I';
        
    if (Op == 'I' || Op == 'i')
    {
        decimal fac = 1.1m;
        for (decimal beg = Num1; beg <= Num2; beg += fac)
        {
            Console.WriteLine("Value of beg is: " + beg);
            Num1 = beg;
                
            Console.WriteLine("Value of Num1 has been updated to: " + Num1);
        }
    }
