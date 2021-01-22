    using System;
    using System.Drawing;
    using System.Reflection;
    
    public class Test
    {
        static void Main()
        {
            var props = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            foreach (PropertyInfo prop in props)
            {
                Color color = (Color) prop.GetValue(null, null);
                Console.WriteLine("Color.{0} = ({1}, {2}, {3})", prop.Name,
                                  color.R, color.G, color.B);
            }
        }
    }
