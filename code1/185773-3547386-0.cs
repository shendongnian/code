    public class MyClassBase<T>
    {
        protected void DoStuff(params T[] arguments)
        {
            // do more stuff with arguments
        }
    }
    class MyClass : MyClassBase<string>
    {
        void MakeCall()
        {
            DoStuff("abc");
        }
    }
