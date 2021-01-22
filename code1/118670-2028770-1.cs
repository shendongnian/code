    public class OneType
    {
    }
    public class MyClass<T> where T : OneType
    {
        T MyObj
        { get; set; }
        public MyClass(T obj)
        {
        }
        public static MyClass<T> Factory<T>(T vd)
          where T : OneType
        {
            if (vd is TwoType)
            {
                return (MyClass<T>)(object)new SubClass(vd as TwoType);
            }
            return null;
        }
        public string Working
        {
            get { return this.GetType().Name; }
        }
    }
    public class TwoType : OneType
    {
    }
    public class SubClass : MyClass<TwoType>
    {
        public SubClass(TwoType obj)
            : base(obj)
        {
        }
    }
