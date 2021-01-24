    public class ClassA
    {
        public ClassA(string message)
        {
        }
        public ClassA()
        {
        }
    }
    public class HelperClass<T> : ClassA
    {
        public string Name { get; }
        public HelperClass() => this.Name = nameof(T);
      
        public HelperClass(string message) : this()
        {
        }
    }
    public class ClassD : HelperClass<ClassD>
    {
        public ClassD()
        {
        }
        public ClassD(string message) : base(message)
        {
        }
    }
