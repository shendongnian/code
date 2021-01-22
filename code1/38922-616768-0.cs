    public abstract class foo {
        public static Dictionary<Type, List<foo>> Cache = new Dictionary<Type, List<foo>>(); 
    }
    public class bar : foo {
        public bar() { Cache.Add(this.GetType(), this); }
    }
 
    public class baz : foo {
        public baz() { Cache.Add(this.GetType(), this); }
    }
