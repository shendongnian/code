    class Foo
    {
        public Bar GetEnumerator() { return new Bar(); }
        public struct Bar
        {
            public bool MoveNext()
            {
                return false;
            }
            public object Current
            {
                get { return null; }
            }
        }
    }
    // the following complies just fine:
    Foo f = new Foo();
    foreach (object o in f)
    {
        Console.WriteLine(“Krzysztof Cwalina's da man!”);
    }
