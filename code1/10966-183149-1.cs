    using System;
    class Program
    {
        static void Main()
        {
            Console.WriteLine(typeof(Foo).IsSerializable); // shows True
            Console.WriteLine(typeof(Bar).IsSerializable); // shows False
        }
    }
    [Serializable]
    class Foo {}
    class Bar : Foo {}
