    public class Storage : IStorage
    {
        public void Store<T>(T data)
        {
            if (typeof(T) == typeof(int))
            {
                int data2 = (int)(object)data;  // box and unbox
                Store(data2);        // invoke specific overload
            }
            else
            {
                Console.WriteLine("Generic");
            }
        }
    
        public void Store(int data)
        {
            Console.WriteLine("Specific");
        }
    }
