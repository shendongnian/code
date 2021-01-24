    internal class MyClass
    {
        public MyClass(GetElement getElement)
        {
            GetElement = getElement;
        }
        public GetElement GetElement { get; }
    }
    internal delegate Element GetElement();
    internal class Element
    {
    }
