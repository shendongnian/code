    public static void DrawBox(int h, int w)
    {
       Console.WriteLine(new string('*', w));
       for (var i = 0; i < h-2; i++)
          Console.WriteLine($"*{new string(' ', w - 2)}*");
       Console.WriteLine(new string('*', w));
    }
