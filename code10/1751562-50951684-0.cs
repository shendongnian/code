    var random = new Random();
    System.Drawing.Color c;
    unchecked
    {
    	c = System.Drawing.Color.FromArgb((int)0xFF000000 + (random.Next(0xFFFFFF) & 0x7F7F7F));
    }
    Console.WriteLine(c);
