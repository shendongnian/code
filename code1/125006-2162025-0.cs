    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestGener234
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("his first name is {0}", GetPropertyValue<string>("firstName"));
                Console.WriteLine("his age is {0}", GetPropertyValue<int>("age"));
            }
    
            public static T GetPropertyValue<T>(string propertyIdCode)
            {
                if (typeof(T) == typeof(string) && propertyIdCode == "firstName")
                    return "Jim";
                if (typeof(T) == typeof(string) && propertyIdCode == "age")
                    return "32";
                if (typeof(T) == typeof(int) && propertyIdCode == "age")
                    return 32;
                throw (new ArgumentException());
            }
        }
    }
