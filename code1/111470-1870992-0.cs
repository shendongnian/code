    public class B<T> { }
    public class D : B<int> { }
    public class A<T> where T : D { }
    public class C : A<D> { }
    public class Test1 { public class test1 { A<D> t = new C();    } }
