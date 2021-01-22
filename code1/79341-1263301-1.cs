    public static void Main(string[] args)
    {
      MyClass myClass = new MyClass();
      CallGetEnumerator<MyEnum, string>(myClass);
      CallGetEnumerator<string, string>(myClass);
    }
    .    
    .
    public static void CallGetEnumerator<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
    {
      foreach(var v in enumerable) {...}
    }
