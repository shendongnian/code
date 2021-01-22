    public static void DoSomething<K,V>(IDictionary<K,V> items)
      where V : IEnumerable
    {
       items.Keys.Each(key => { /* do something */ });
    }
    
    public static void DoSomething<K,V>(IDictionary<K,V> items)
    {
       items.Keys.Each(key => { /* do something else */ });
    }
