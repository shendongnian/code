    class SomeObject
    {
    }
    class MyEnum : List<SomeObject>
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEnum a = new MyEnum();
            a.Add(new SomeObject());
            foreach (SomeObject o in a)
            {
                Console.WriteLine(o.GetType().ToString());
            }
            Console.ReadLine();
        }
    }
