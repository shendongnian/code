    public class MyGenericStack<T>
    {
        int position;
        T[] data = new T[10];
        public void Push(T obj) { data[position++] = obj; }
        public T Pop() { return data[--position]; }
    
        public void Show()
        {
    
            for (int i = 0; i < data.Length; i++)
            {
                //Console.WriteLine("Item: {0}", data[i]);
                //MessageBox.Show(String.Format("Item: {0}", data[i]));
            }
        }
    }
