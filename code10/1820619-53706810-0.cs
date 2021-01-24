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
            public virtual T GetSource(Connection connection, ExternalConnection externalConnection) {
                throw new Exception();
            }
        }
        private class CollectionGetter<T> : SourceGetter<T> where T : SomeBase {
            public override T GetSource(Connection connection, ExternalConnection externalConnection) {
                return connection.GetSource<T>();
            }
        }
        ...
        public T GetSource<T>()
        {
            return SourceGetter<T>.Instance.GetSource(_connection, _exconnection);
        }
    
        private Connection _connection;
        private ExternalConnection _exconnection;
    }
