    static void Main(string[] args)
    {
    
        MyClass cls  = new MyClass();
        Console.Write("Write a number: ");
        long a= Convert.ToInt64(Console.ReadLine()); // a is the number given by the user
        long av = cls.volteado(a);
        bool isTrue = cls.siprimo(a);
        ......etc
       
    }
