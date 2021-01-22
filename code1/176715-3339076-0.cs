    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<BaseType> {new TypeA(), new TypeB()};
            IEnumerable<TypeA> results = list.Where(x => x is TypeA).Cast<TypeA>();
            Console.WriteLine("Succeeded. Press any key to quit.");
            Console.ReadKey();
        }
    
        public class BaseType{}
        public class TypeA : BaseType {}
        public class TypeB : BaseType {}
    }
