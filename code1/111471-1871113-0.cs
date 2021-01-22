    public class B<T> {}
    public class D : B<int> {}
    public class A<T, S> where T : B<S> {}
    public class C : A<D, int> {}
    public class Test1 {
        public class test1 {
            A<D, int> t = new C();
        }
    }
