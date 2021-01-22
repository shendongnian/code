    public class Foo
    {
       private ISet<Bar> _bars = new HashSet<Bar>();
       public ReadOnlyCollection<Bar> Bars { get return new List<Bar>(_bars).AsReadOnly(); }
       public void AddBar( Bar b )
       {
          b.Parent = this;
          _bars.Add (b);
       }
   
       public void RemoveBar( Bar b )
       {
          b.Foo = null;
          _bars.Remove (b);
       }
    }
    public class Bar
    {
         public Foo Parent { get; set; }
    }
