    public interface Ixyz
    {
        void XYZ();
    }
    public class MyGenericClass<T> : Ixyz where T:Ixyz, new()
    {
        T obj;
        public MyGenericClass()
        {
            obj = new T();
        }
        public void XYZ()
        {
            obj.XYZ();
        }
    }
