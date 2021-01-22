     public class DependencyObject
    {
        public void DependencyObjectMethod() { }
    }
    public class A : DependencyObject
    {
        public void MethodA() { }
    }
    public class B : A
    {
        public void MethodB() { }
    }
    public class C : B
    {
        public void MethodC()
        {
            //Do Something
        }
    }
