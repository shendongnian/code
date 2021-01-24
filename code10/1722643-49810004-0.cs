    public class Stack
    {
        int position;
        object[] data = new object[10]; // Why 10 nor 1? 
        public void Push (object obj) { data[position++] = obj; }
        public object Pop() { return data[--position]; }
    }
