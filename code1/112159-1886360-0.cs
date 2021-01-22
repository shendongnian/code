    class SomeType {
        static SomeType() {
            Console.WriteLine("SomeType.cctor");
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Init() { }
    }
    
    static class Program {
        static void Main() {
            SomeType.Init();
            Console.WriteLine("hi");
        }
    }
