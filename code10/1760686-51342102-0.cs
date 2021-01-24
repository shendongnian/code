      using System;
      namespace ConsoleApp2
      {
      class Program
      {
        static void Main(string[] args)
        {
            IStuff IStuff = new DerivedClass1("data1 here");
            IStuff.DoStuff(); // prints "1: data here"
            IStuff = new DerivedClass2("data2 here");
            IStuff.DoStuff(); // prints "1: data here"
            Console.ReadKey();
        }
        public class BaseClass
        {
            public BaseClass(string data)
            {
                Data = data;
            }
            public string Data { get; set; }
        }
        // Interface for derived Classes:
        public interface IStuff
        {
            void DoStuff();
        }
        // Derived Classes: 
        // (Don't have own Properties besides the ones they get from BaseClass and 
        // no other Methods than they have to implement from IStuff)
        public class DerivedClass1 : BaseClass, IStuff
        {
            public DerivedClass1(string data) : base(data)
            {
            }
            public void DoStuff()
            {
                Console.WriteLine($"1: {Data}");
            }
        }
        public class DerivedClass2 : BaseClass, IStuff
        {
            public DerivedClass2(string data) : base(data)
            {
            }
            public void DoStuff()
            {
                Console.WriteLine($"2: {Data}");
            }
        }
        //UnknownType GetDerivedClass(BaseClass baseClass, int value)
        //{
        //    switch (value)
        //    {
        //        case 1:
        //            return baseClass as DerivedClass1;
        //        case 2:
        //            return baseClass as DerivedClass2;
        //        default:
        //            return null;
        //    }
        //}
        //var value = 1;
    }
    }
