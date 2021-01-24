    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace CodeStuff
    {
        public abstract class Automobile
        {
            public abstract void stuff();
        }
        public class Car : Automobile
        {
            public override void stuff()
            {
                Console.WriteLine("nice");
            }
        }
        class Program
        {
            public static void CarStuff(Automobile b)
            {
                b.stuff();
            }
            static void Main(string[] args)
            {
                Type ReadType = Type.GetType("CodeStuff.Car");
                Object obj = Activator.CreateInstance(ReadType);
                CarStuff((Automobile)obj);
                Console.ReadLine();
            }
        }
    }
