    interface IInterface
    {
        string SampleString { get; }
    }
    // Fix MyClass
    class MyClass : IInterface
    {
        public string SampleString => "Hello There"
    }
    class ClassUnderTest
    {
        public string MethodUnderTest(IInterface someObject)
        {
            string stringToBeTested = string.Empty;
            if (someObject.SampleString.Contains("."))
                stringToBeTested = string.Empty;
            else
                stringToBeTested = str.Replace(" ", string.Empty);
            return stringToBeTested;
        }
    }
