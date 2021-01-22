    static void Main()
    {
        
        Test(Color.Red);
        Test(Color.FromArgb(34,125,75));
    }
    static void Test(Color color)
    {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Color));
        string s = converter.ConvertToInvariantString(color);
        Console.WriteLine("String: " + s);
        Color c = (Color) converter.ConvertFromInvariantString(s);
        Console.WriteLine("Color: " + c);
        Console.WriteLine("Are equal: " + (c == color));
    }
