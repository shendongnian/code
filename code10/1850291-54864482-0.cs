    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp4
    {
        public enum Color
        {
            Red,
            Green,
            Blue
        }
        public static class EnumCombo
        {
            public static List<T> ToCombo<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToList();
            }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var results = EnumCombo.ToCombo<Color>();
    
                Console.ReadLine();
            }
        }
    }
