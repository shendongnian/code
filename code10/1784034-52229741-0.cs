    public class A
    {
        static A()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            B.DoNothing();
        }
        public static void DoNothing() { }
    }
    public class B
    {
        static B()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            A.DoNothing();
        }
        public static void DoNothing() { }
    }
    private static void Main()
    {
        Task.Run(() => B.DoNothing());
        A.DoNothing();
    }
