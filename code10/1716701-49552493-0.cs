    public abstract class A<T>
    {
        abstract protected void myMethod(List<T> myList);
    }
    public class B : A<DateTime>
    {
        protected override void myMethod(List<DateTime> myList)
        {
            var date = myList[0].ToString("dd-MM-yyyy");
        }
    }
