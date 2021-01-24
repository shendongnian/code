    public class SourceFactory {
        private class SourceGetter<T> {
            public static readonly SourceGetter<T> Instance;
            static SourceGetter() {
                Type listType = typeof(T);
                if (listType == typeof(SomeBase))
                {
                    Instance = (SourceGetter<T>)Activator.CreateInstance(typeof(CollectionGetter<>).MakeGenericType(listType));
                }
                else if(listType == typeof(ExternalBase)){
                    Instance = ...            }
                else {
                    Instance = new SourceGetter<T>();
                }
            }
            public virtual T GetSource(SourceFactory sourceFactory) {
                throw new Exception();
            }
        }
        private class CollectionGetter<T> : SourceGetter<T> where T : SomeBase {
            public override T GetSource(SourceFactory sourceFactory) {
                return sourceFactory._connection.GetSource<T>();
            }
        }
        ...
        public T GetSource<T>()
        {
            return SourceGetter<T>.Instance.GetSource(this);
        }
    
        private Connection _connection;
        private ExternalConnection _exconnection;
    }
