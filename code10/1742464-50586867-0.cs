    interface IInterface
    {
        string SampleString { get; }
    }
    // then also changing MyClass to
    class MyClass
    {
        public string SampleString => "Hello There"
    }
    // and that:
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
