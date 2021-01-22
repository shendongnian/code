    public class IAcceptValueTypes<T> where T: struct
    private T obj;
    public T Obj
    {
        get { return obj; }
        set { obj = value; }
    }
