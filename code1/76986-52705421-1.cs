    static void Main()
    {
        Console.Write("x: ");
        var x = System.Convert.ToInt32(Console.ReadLine());
        // ERROR: CS0149 - Method name expected 
        foreach (var elem in () =>
        {
            var i = x;
            do
            {
                yield return i;
                i += 1;
                x -= 1;
            }
            while (!i == x + 20);
        }())
            Console.WriteLine($"{elem} to {x}");
        Console.ReadKey();
    }
