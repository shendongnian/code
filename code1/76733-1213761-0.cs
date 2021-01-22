    public class RollingWindow<T> : IEnumerable<T>
    {
        private readonly T[] data;
        private int head;
        private int nextInsert = 0;
      
        public RollingWindow(int size)
        {
            if (size < 1)
                throw new Exception();
            this.data = new T[size];
            this.head = -size;
        }
    
        public void Add(T t)
        {
            data[nextInsert] = t;
            nextInsert = (nextInsert + 1) % data.Length;
            if (head < 0)
                head++;   
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            if (head < 0)
            {
                for (int i = 0; i < nextInsert; i++)
                    yield return data[i];
                yield break;
            }
            else
            {
                for(int i = 0; i < data.Length; i++)
                {
                    yield return data[(nextInsert + i) % data.Length];        
                }
            }
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
