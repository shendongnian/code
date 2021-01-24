    public static void Cos()
    {
        for (double x = 0; x <= Math.PI * 2; x += Math.PI * .1)
        {
            Console.WriteLine("Cos({0})PI = {1}", x, Math.Cos(x));
        }
    }
