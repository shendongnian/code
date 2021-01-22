    using System;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        public static class MyDictionary
        {
            public static int[] intArray = new int[] { 0, 1, 2 };
            public static string[] stringArray = new string[] { "zero", "one", "two" };
        }
        
        static class Program
        {
            static void Main(string[] args)
            {
                FieldInfo[] fields = typeof(MyDictionary).GetFields();
                
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType.IsArray)
                    {
                        Array array = field.GetValue(null) as Array;
                        
                        Console.WriteLine("Type: " + array.GetType().GetElementType().ToString());
                        Console.WriteLine("Length: " + array.Length.ToString());
                        Console.WriteLine("Values");
                        Console.WriteLine("------");
                        
                        foreach (var element in array)
                            Console.WriteLine(element.ToString());
                    }
                    
                    Console.WriteLine();
                }
                
                Console.Readline();
            }
        }
    }
