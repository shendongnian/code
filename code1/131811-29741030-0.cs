    public class meta {
        public virtual Guid id { get; set; }
        public virtual IDictionary<string, string> data { get; set; }
        public meta() {
            data = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        }
    }
    public class metamap : ClassMap<meta> {
        public metamap() {
            Table("metatable");
            Id(x=>x.id);
            HasMany(x => x.data)
                .Table("metadata")
                .AsMap<string>("skey")
                .Element("value")
                .CollectionType<DictionaryInsensitive<string>>()
                .Cascade.All()
                .KeyColumn("metaid");
        }
    }
    public class DictionaryInsensitive<T> :  IUserCollectionType {
        bool IUserCollectionType.Contains(object collection, object entity) {
            return ((IDictionary<string,T>) collection).Values.Contains((T)entity);
        }
        System.Collections.IEnumerable IUserCollectionType.GetElements(object collection) {
            return ((IDictionary<string,T>) collection).Values;
        }
        object IUserCollectionType.IndexOf(object collection, object entity) {
            var dictionary = (IDictionary<string, T>)collection;
            return dictionary
                    .Where(pair => Equals(pair.Value, entity))
                    .Select(pair => pair.Key)
                    .FirstOrDefault();
        }
        object IUserCollectionType.Instantiate(int anticipatedSize) {
            return
                new Dictionary<string, T>(
                    StringComparer.InvariantCultureIgnoreCase);
        }
        NHibernate.Collection.IPersistentCollection IUserCollectionType.Instantiate(NHibernate.Engine.ISessionImplementor session, NHibernate.Persister.Collection.ICollectionPersister persister) {
            return new PersistentGenericMap<string, T>(session);
        }
        object IUserCollectionType.ReplaceElements(object original, object target, NHibernate.Persister.Collection.ICollectionPersister cp, object owner, System.Collections.IDictionary copyCache, NHibernate.Engine.ISessionImplementor session) {
            IDictionary<string, T> result = (IDictionary<string, T>)target;
            result.Clear();
            IEnumerable<KeyValuePair<string, T>> iter = (IDictionary<string, T>)original;
            foreach (KeyValuePair<string, T> me in iter) {
                string key = (string)cp.IndexType.Replace(me.Key, null, session, owner, copyCache);
                T value = (T)cp.ElementType.Replace(me.Value, null, session, owner, copyCache);
                result[key] = value;
            }
            var originalPc = original as IPersistentCollection;
            var resultPc = result as IPersistentCollection;
            if (originalPc != null && resultPc != null) {
                if (!originalPc.IsDirty)
                    resultPc.ClearDirty();
            }
            return result;
        }
        NHibernate.Collection.IPersistentCollection IUserCollectionType.Wrap(NHibernate.Engine.ISessionImplementor session, object collection) {
            var dict = new Dictionary<string, T>();
            return new PersistentGenericMap<string, T>(session, (IDictionary<string,T>)collection);
        }
    }
