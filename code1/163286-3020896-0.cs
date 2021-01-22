    using System;
    using System.Drawing;
    
    class Test
    {
        static Color SetTransparency(int A, Color color)
        {
            return Color.FromArgb(A, color.R, color.G, color.B);
        }
        
        static void Main()
        {
            Color halfTransparent = SetTransparency(127, Color.Black);
            Console.WriteLine(halfTransparent.A); // Prints 127
        }
    }
