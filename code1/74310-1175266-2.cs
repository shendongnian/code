    using System;
    public class myClass<T> where T : new()
    {
        public T Value;
        public void CopyFromSecond(object caller)
        {
            myClass<T> test = caller as myClass<T>;
            this.Value = test.Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            myClass<int> test = new myClass<int> { Value = 3 };
            myClass<int> test2 = new myClass<int> { Value = 5 };
            Console.WriteLine(test.Value);
            test.CopyFromSecond(test2);
            Console.WriteLine(test.Value);
            Console.ReadKey();
        }
    }
