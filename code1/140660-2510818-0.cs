    public class A<T> where T : struct
    {
        public List<T> data;
        public Type type;
    }
    
    public void FillData<DataType>(DataType[] data) where DataType : struct
    {
        A<DataType> a = new A<DataType>();
        a.data = new List<DataType>();
        a.AddRange(data);
    }
