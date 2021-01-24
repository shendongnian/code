    public class MyClass<T> : IEnumerable<T>
    {
        public List<T> Collection { get; set;}
    
        public T this[int index]  
        {  
            get { return Collection[index]; }  
            set { Collection.Insert(index, value); }  
        } 
        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public MyClass()
        {
            Collection = new List<T>();
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            var instance = new MyClass<int>();
    
            instance.Collection.Add(1);
            instance.Collection.Add(2);
            instance.Collection.Add(3);
            
            
            foreach(int item in instance)
                Console.WriteLine(item);
        }
    }
