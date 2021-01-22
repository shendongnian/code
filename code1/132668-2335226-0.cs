    [Serializable()]
    public class Foo
    {
      public IList<Number> Nums { get; set; }
    
      public long GetValueTotal()
      {
        return Nums.Sum(x => x.value);
      }
    }
