    class DerivedClass : BaseClass {
       void Main() {
          int i = @int["Key"];
       }
    }
    abstract class BaseClass {
       private Dictionary<string, string> D { get; set; }
       protected Indexer<int> @int = new Indexer<int>(s => int.Parse(s), this);
       protected Indexer<string> @string = new Indexer<string>(s => s, this);
       protected Indexer<object> @object = new Indexer<object>(s => (object)s, this);
       protected class Indexer<T> {
           public T this[string key] {
              get { return this.Convert(this.BaseClass.D[key]); }
           }
           private T Convert(string value) { get; set; }
           private BaseClass { get; set; }
           public Indexer(Func<T, string> c, BaseClass b) {
              this.Convert = c;
              this.BaseClass = b;
           }
       }    
    }
