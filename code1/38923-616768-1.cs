    public abstract class foo {
        public abstract List<foo> Cache { get; }
        protected static Dictionary<Type, List<foo>> InnerCache = new Dictionary<Type, List<foo>>(); 
    }
    public class bar : foo {
        public override List<foo> Cache { 
           get { return foo.InnerCache[typeof(bar)]; } 
        }
        public bar() { Cache.Add(this); }
    }
 
    public class baz : foo {
        public override List<foo> Cache { 
           get { return foo.InnerCache[typeof(baz)]; } 
        }
        public baz() { Cache.Add(this); }
    }
