    public class InMemoryStore<T, U, V> : Store<T, U>
        where T : StorableEntity<U>
        where V : IUIDGenerator<U> {
        public override U GetUniqueIdentifier()
        {
            return (V)(Activator.CreateInstance<V>()).Create();
        }
    }
