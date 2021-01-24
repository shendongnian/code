    using System;
    using System.Reflection;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                getPRopNames(typeof(Person));
    
            }
    
            public static void getPRopNames(Type fromObject)
            {
                foreach (PropertyInfo oneProp in fromObject.GetProperties())
                {
                    if (oneProp.PropertyType.IsValueType || oneProp.PropertyType == typeof(string))
                    {
                        Console.WriteLine(oneProp.Name);
                    }
                    else
                    {
                        getPRopNames(oneProp.PropertyType);
                    }
                }
            }
        }
    
        public class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; }
        }
    
        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
        }
    }
