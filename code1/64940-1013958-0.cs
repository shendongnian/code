    public interface ISomeOtherClass
    {
    }
    public class Class_X : ISomeOtherClass
    {
    }
    public class Class_Y : ISomeOtherClass
    {
    }
    public class BaseClass<T> where T : ISomeOtherClass
    {
       public ListRef<T> OtherObjects { get; set; }
    }
    public class A : BaseClass<Class_x>
    {
    }
    public class B : BaseClass<Class_Y>
    {
    }
