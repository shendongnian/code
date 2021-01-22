    public class B<T> {}
    public class D : B<int> {}
    public class A<U, V> where U : B<V> {}
    public class C : A<D, int> {}
    public class Test1 {
        public class test1 {
            A<D, int> t = new C();
        }
    }
