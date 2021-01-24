    /// <summary>
    /// T can only be an int or double or will throw an exception on construction.
    /// </summary>
    public class A<T>
    {
        public A()
        {
            if (!(property is int || property is double))
                throw new Exception("A can only work with int and double");
        }
        public T property  { get; set; }
    }
