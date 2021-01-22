    using System;
    using System.Drawing;
    
    public class Test
    {
        static void Main()
        {
            foreach (KnownColor known in Enum.GetValues(typeof(KnownColor)))
            {
                Color color = Color.FromKnownColor(known);
                Console.WriteLine("Color.{0} = ({1}, {2}, {3})", known,
                                  color.R, color.G, color.B);
            }
        }
    }
