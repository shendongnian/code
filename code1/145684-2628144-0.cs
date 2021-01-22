    public struct SomeStruct
    {
        public int PublicProperty { get; set; }
        public int PublicField;
        public SomeStruct(int propertyValue, int fieldValue)
            : this()
        {
            PublicProperty = propertyValue;
            PublicField = fieldValue;
        }
        public int GetProperty()
        {
            return PublicProperty;
        }
        public void SetProperty(int value)
        {
            PublicProperty = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SomeStruct a = new SomeStruct(1, 1);
            a.PublicProperty++;
            a.SetProperty(a.GetProperty()+1);
        }
    }
