    MySubType foo = new MySubType();
    MySubType bar = new MySubType();
    foo.DoStuff(bar);
    // ...
    public class MySubType : MyBaseType<MySubType>
    {
    }
    public class MyBaseType<T>
    {
        public void DoStuff(T arg1)
        {
            // do stuff
        }
    }
