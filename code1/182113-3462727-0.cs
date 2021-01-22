    public class Lazy<T>
    {
        public Lazy( Func<T> f ) { /*...*/ }
       public static Lazy<R> Default<R>() where R : T, new()
       {
           return new Lazy<R>( () => new R() );
       }
    }
