    public class Foo
    {
       private static Dictionary<string, Foo> Foos = 
          new Dictionary<string, Foo>();
       public static Foo Create(string key)
       {
          if (Foos.ContainsKey(key)) return Foos[key];
          Foos.Add(key, new Foo(key));
       }
       public string Key { get; set; }
       private Foo(string key)
       {
          Key = key;
       }
    }
