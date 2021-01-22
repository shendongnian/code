    internal class A<T>
    {
        public static implicit operator A<T><From>(A<From> x)
        {
            return new A<T>();
        }
    }
    
    public class a
    {
        public static void Main()
        {
            A<Derived> a = new A<Derived>();
            A<Base> a2 = (A<Base>) a;
            Console.WriteLine(Convert.ToString(a) + " " + Convert.ToString(a2));
        }
    }
