    interface Inx<T> { 
        T Set(Data data);
    }
    public class Base
    {
        public virtual T Set<T>(Data data)
        {
            T t = default(T);
            return t;
        }
    }
    public class Parent : Base, Inx<Parent>
    {
        public Parent Set(Data data)
        {
            return base.Set<Parent>(data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            var list = new List<Parent>();
            list.Add(new Parent().Set<Parent>(data));
            // or 
            list.Add(new Parent().Set(data));
        }
    }
