    using System;
    internal interface IAnimal
    {
    }
    internal class Cat : IAnimal
    {
    }
    class Program
    {
        static void Main()
        {
            var cat = new Cat();
            Console.WriteLine(cat.GetType()); // Cat
            Console.WriteLine(GetStaticType(cat)); // Cat
            IAnimal animal = cat;
            Console.WriteLine(GetStaticType(animal)); // IAnimal
        }
        static Type GetStaticType<T>(T _)
        {
            return typeof (T);
        }
    }
