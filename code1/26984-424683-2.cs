    class SampleCollection<T>
    {
        private T[] arr = new T[100];
        public T this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }
    }
    
    // This class shows how client code uses the indexer
    class Program
    {
        static void Main(string[] args)
        {
            SampleCollection<string> stringCollection = 
                new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            System.Console.WriteLine(stringCollection[0]);
        }
    }
