    public abstract class A
    {
        abstract protected void myMethod<T>(List<T> myList);
    }
    public class B : A
    {
        protected override void myMethod<DateTime>(List<DateTime> myList)
        {
        }
    }
