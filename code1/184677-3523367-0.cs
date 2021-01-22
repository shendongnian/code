    public class IMyClassFactory
    {
        public static IMyClass CreateInstance(string item)
        {
            switch(item)
            {
                case "SomeValue":
                case "SomeValue2":
                    return new MyClass1(item);
                case "SomeOtherValue":
                    return new MyClass2(item);
            }
        }
    }
