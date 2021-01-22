    public abstract class Test<TKey>
    {
        TKey Key { get; set; }
    }
    
    public abstract class Wrapper<TValue, TKey>
        where TValue : Test<TKey>
    {
        public TValue Value { get; set; }
    }
    public class TestWrapper<TKey> : Wrapper<Test<TKey>, TKey>
    { }
    // ... some code somewhere
    var tw = new TestWrapper<int>();
    Test<int> value = tw.Value;
