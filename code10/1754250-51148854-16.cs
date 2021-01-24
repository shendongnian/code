    public class A<T> where T : struct
    {
        //constructor surely can have arguments
        private A()
        {
        }
        public T property { get; set; }
        //and other common stuff
        //each class declaration below we can treat like "where" constraint
        public class A_int : A<int> { }
        public class A_double : A<double> { }
    }
    //compile time error:
    //'A<bool>.A()' is inaccessible due to its protected level
    public class Test : A<bool>
    {
    }
