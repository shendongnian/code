    static void Main()
    {
        var genericSize = new Size
        {
            Width = 20,
            Height = 30,
            Length = 40,
            Units = UnitOfMeasure.Inches
        };
        var brassLamp = new Lamp { Size = genericSize };
        var glassChandelier = new Chandelier { Size = genericSize };
        var plushRug = new Rug { Size = genericSize };
        Console.WriteLine($"Brass lamp: {brassLamp.GetSize()}");
        Console.WriteLine($"Chandelier: {glassChandelier.GetSize()}");
        Console.WriteLine($"Plush Rug: {plushRug.GetSize()}");
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
