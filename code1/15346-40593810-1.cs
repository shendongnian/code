    public class ChildA : Mother<ChildA>
    {
        public override void DoSomething() { Console.WriteLine("42"); }
    }
    public class ChildB : Mother<ChildB>
    {
        public override void DoSomething() { Console.WriteLine("12"); }
    }
    public class WhoCare
    {
        static void Main()
        {
            ChildA.Do();  //42
            ChildB.Do();  //12
            Console.ReadKey();
        }
    }
