    public class SomeClass
    {
        public int SomeInt { get; set; }
    
        public static SomeClass Create(int defaultValue)
        {
            SomeClass result = new SomeClass();
            result.SomeInt = defaultValue;
            return result;
        }
    }
