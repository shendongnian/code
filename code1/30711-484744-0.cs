    public struct StructExample
    {
        public string Val;
    }
    public class MyClass
    {
        private StructExamle example;
        public MyClass()
        {
            example = null; // will give you a 'Cannot convert to null error
        }
        public StructExample GetXyz()
        {
            return null; // also gives the same error
        }
    }
