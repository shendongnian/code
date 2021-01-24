    public class Foo : TheClassThatDefinesLoad
    {
        public event EventHandler Loaded;
        protected override V Load(DbDataReader dr)
        {
            var result = base.Load(dr);
            // An event handler with no listeners is null by default
            if (Loaded != null)
                Loaded.Invoke(this, new EventArgs());
            return result;
        }
    }
    // Somewhere in the calling code:
    int loads = 0;
    var foo = new Foo();
    foo.Loaded += (sender, args) => loads += 1;
