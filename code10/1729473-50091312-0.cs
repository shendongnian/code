    abstract class Param<T> 
    {
        public T value;
        private string name;
    
        public Param(string name)
        {
            this.name = name;
        }
    }
    class Param_Double: Param<double>
    {
        public Param_Double(string name) : base(name)
        {
            this.value = 1.0;
        }
    }
