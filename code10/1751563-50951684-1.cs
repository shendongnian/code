    var random = new Random();
    System.Drawing.Color c;
    unchecked
    {
    	var n = (int)0xFF000000 + (random.Next(0xFFFFFF) & 0x7F7F7F);
    	Console.WriteLine($"ARGB: {n}");
    	c = System.Drawing.Color.FromArgb(n);
    }
    Console.WriteLine($"A: {c.A}");
    Console.WriteLine($"R: {c.R}");
    Console.WriteLine($"G: {c.G}");
    Console.WriteLine($"B: {c.B}");
