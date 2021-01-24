    class MyClass : JObject, IEnumerable<KeyValuePair<string, int>>
    {
        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Foo : MyClass { }
    class FooBar : Foo { }
    public void Test<T>(IEnumerable<KeyValuePair<string, T>> kvp)
    {
       Console.WriteLine(kvp.GetType().Name + ": KeyValues");
    }
    var fooBar = new FooBar();
    Test(fooBar);
