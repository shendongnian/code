    public abstract class MyHelper {
        public static V GetValueOrDefault<K,V>( Dictionary<K,V> dic, K key ) {
            V ret;
            bool found = dic.TryGetValue( key, out ret );
            if ( found ) { return ret; }
            return default(V);
        }
    }
    var x = MyHelper.GetValueOrDefault( dic, key );
