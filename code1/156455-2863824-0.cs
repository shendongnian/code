    using System;
    using System.ComponentModel;
    [Description("This is a wahala class")]
    public class Wahala
    {    
    }
    
    public class Test
    {
        static void Main()
        {
            Console.WriteLine(GetDescription(typeof(Wahala)));
        }
        
        static string GetDescription(Type type)
        {
            var descriptions = (DescriptionAttribute[])
                type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            
            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }
    }
