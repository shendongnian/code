    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            String fontName = "Arial, 12.5";
            String[] fontNameFields = fontName.Split(',');
            String name = fontNameFields[0];
            float size = float.Parse(fontNameFields[1]);
            Console.WriteLine("{0}: {1}", name, size);
        }
    }
