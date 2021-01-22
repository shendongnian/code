    using System;
    using System.ComponentModel;
    using System.Reflection;
    
    class Test
    {
        [Description("Auto-implemented property")]
        public static string Foo { get; set; }  
    
        static void Main(string[] args)
        {
            var property = typeof(Test).GetProperty("Foo");
            var attributes = property.GetCustomAttributes
                    (typeof(DescriptionAttribute), false);
    
            foreach (DescriptionAttribute description in attributes)
            {
                Console.WriteLine(description.Description);
            }
        }
    }
