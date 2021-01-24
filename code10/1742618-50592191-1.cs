    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                object reflectThis = typeof(ToBeReflected).GetProperty("ReflectThis", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
                int objIndex = 0;
                foreach(object obj in (reflectThis as IEnumerable))
                {
                    Type objType = obj.GetType();
                    List<int> ints = (List<int>)objType.GetField("Ints", BindingFlags.Public | BindingFlags.Instance).GetValue(obj);
                    int num1 = (int)objType.GetField("num1", BindingFlags.Public | BindingFlags.Instance).GetValue(obj);
                    int num2 = (int)objType.GetField("num2", BindingFlags.Public | BindingFlags.Instance).GetValue(obj);
                    Console.WriteLine("Object #" + objIndex);
                    Console.WriteLine("  Ints: " + string.Join(",", ints));
                    Console.WriteLine("  num1: " + num1);
                    Console.WriteLine("  num2: " + num2);
                    objIndex++;
                }
            }
        }
    
        public class ToBeReflected
        {
            private static List<SomePrivateClassInsideIt> ReflectThis { get; } = new List<SomePrivateClassInsideIt>();
    
            private class SomePrivateClassInsideIt
            {
                public readonly List<int> Ints;
                public int num1;
                public int num2;
    
                public SomePrivateClassInsideIt(List<int> ints)
                {
                    Ints = ints;
                }
            }
    
            static ToBeReflected()
            {
                ReflectThis.Add(new SomePrivateClassInsideIt(new List<int> { 0, 1 }) { num1 = 2, num2 = 3 });
                ReflectThis.Add(new SomePrivateClassInsideIt(new List<int> { 4, 5 }) { num1 = 6, num2 = 7 });
            }
        }
    }
