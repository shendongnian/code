    public static void DrawBox(int h, int w)
    {
       var hoz = new string('*', w);
       var vet = "*" + new string(' ', w - 2) + "*";
    
       Console.WriteLine(hoz);
       for (var i = 0; i < h - 2; i++)
          Console.WriteLine(vet);
       Console.WriteLine(hoz);
    }
