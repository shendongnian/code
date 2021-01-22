    interface Inx<T> { 
        T Set(Data data);
    }
    public class Base<T> : Inx<T>
    {
        public virtual T Set(Data data)
        {
            T t = default(T);
            return t;
        }
    }
    public class Parent : Base<Parent>
    {        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            var list = new List<Parent>();
            list.Add(new Parent().Set(data));            
        }
    }
