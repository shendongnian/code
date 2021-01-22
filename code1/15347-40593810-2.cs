    public abstract class Mother<T> where T : Mother<T>, new()
    {
        public abstract void DoSomething();
    
        public static void Do()
        {
            (new T()).DoSomething();
        }
    }
    public class ChildA : Mother<ChildA>
    {
        public override void DoSomething() { /* Your Code */ }
    }
    
    public class ChildB : Mother<ChildB>
    {
        public override void DoSomething() { /* Your Code */ }
    }
