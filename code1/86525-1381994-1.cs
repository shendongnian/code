    // consumes 2 * IntPtr.Size
    internal abstract class OptionalList
    {
        public string Id { get; set}    
        public OptionalList Next {get; set;}
    }
    
    // consumes sizeof(T)
    internal class Node<T> : OptionalList
    {
        public T Value { get; set; } 
    }
