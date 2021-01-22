    class Program
    {
        static void Main(string[] args)
        {
            MySingletonClass r1 = MySingletonClass.GetInstance();
            Console.WriteLine("R1 value = {0}", r1.ValueGetter());
            r1.ValueSetter("Changed through R1");
            MySingletonClass r2 = MySingletonClass.GetInstance();
            Console.WriteLine("R2 value = {0}", r2.ValueGetter());
            Console.ReadKey();
        }
    }
