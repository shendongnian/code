    public double AMethod()
        {
            Console.WriteLine(cookie.Thickness);
            return (cookie.Thickness); // < you return here ...
            Console.ReadLine();        // so this line will never be executed.
        }
