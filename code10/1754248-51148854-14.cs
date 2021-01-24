    internal abstract class A<T> where T : struct
    {
        public T property { get; set; }
        //and other common stuff
        //each class declaration below we can treat like "where" constraint
        public class A_int : A<int> { }
        public class A_double : A<double> { }
    }
    //compile time error:
    //Inconsistent accessibility: base class 'A<decimal>' is less accessible than class 'Test'
    //because via Test we can expose internal stuff of A<T> to another assemblies
    public class Test : A<decimal>
    {
    }
