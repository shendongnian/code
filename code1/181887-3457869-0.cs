    public class MyClass
    {
        private readonly int value;
        public MyClass(int value)
        {
            this.value = value;
        }
        public static implicit operator MyClass(int value)
        {
            return new MyClass(value);
        }
    }
