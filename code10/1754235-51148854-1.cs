    internal class A<T> where T : struct
    {
        public T property { get; set; }
        //and other common stuff
        public class A_int : A<int>
        {
        }
        public class A_double : A<double>
        {
        }
    }
    //compile time error:
    //Inconsistent accessibility: base class 'A<decimal>' is less accessible than class 'Test'
    public class Test : A<decimal>
    {
    }
