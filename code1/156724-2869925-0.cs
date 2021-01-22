    public static class Helper {
        public static void Using<T>( Action<T> action ) where T : IDisposable, new() {
            var obj = new T();
            action( obj );
        }
    }
    
    // ...
    Helper.Using<MyDisposableClass>( cls => cls.MethodA() );
    Helper.Using<OtherClass>( cls => {
        for( int i = 0; i < 5; i++ ) { cls.DoRandom(); }
    } );
