    public class Program
    {
        public class Foo : IFoo
        {
        }
        [Guid("00000000-0000-0000-0000-000000000000")]
        [CoClass(typeof(Foo))]
        [ComImport]
        public interface IFoo
        {
        }
        static void Main(string[] args)
        {
            IFoo foo = new IFoo();
        }
    }
