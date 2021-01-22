    public interface I1 { int NumberOne { get; set; } }
    public interface I2 { int NumberTwo { get; set; } }
    public static class EitherInterface
    {
        public static void DoSomething<T>(I1 item) where T : I1
        {
            Console.WriteLine("I1 : {0}", item.NumberOne);
        }
        public static void DoSomething<T>(I2 item) where T : I2
        {
            Console.WriteLine("I2 : {0}", item.NumberTwo);
        }
    }
