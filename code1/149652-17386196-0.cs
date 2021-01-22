    using System.Runtime.InteropServices;
    class Bar
    {
        public virtual void func() { }
    }
    [StructLayout(LayoutKind.Explicit)]
    struct Overlaid
    {
        [FieldOffset(0)]
        public object foo;
        [FieldOffset(0)]
        public Bar bar;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var overlaid = new Overlaid();
            overlaid.foo = new object();
            overlaid.bar.func();
        }
    }
