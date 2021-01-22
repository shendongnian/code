    public interface ITypeA<out T> {}
    
    public class TypeA<T> : ITypeA<T> {}
    public class TypeB<T> {}
    public class TypeC : TypeB<int> {}
    class Program
    {
        public static void MyMethod<OutputType>(ITypeA<TypeB<OutputType>> Parameter) {}
        static void Main(string[] args)
        {
            ITypeA<TypeC> Test = new TypeA<TypeC>();
            MyMethod<int>(Test);
        }
    }
