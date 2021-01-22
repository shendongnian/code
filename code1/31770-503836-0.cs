    public class FooClass
    {
       public Stream FooStream { get; private set; }
       public FooClass() : this(null) { }
       public FooClass( Stream stream )
       {
           // provide a default if not specified
           this.FooStream = stream ?? new MemoryStream();
       }
       public void Foo()
       {
           this.FooStream.Write( somebuffer, 0, somebuffer.Length );
       }
    }
