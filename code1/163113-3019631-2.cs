    public abstract class Enumeration<T, TId> : IEquatable<T> where T : Enumeration<T, TId>
    {
        public static bool operator ==(Enumeration<T, TId> x, T y)
        {
            return Object.ReferenceEquals(x, y) || (!Object.ReferenceEquals(x, null) && x.Equals(y));
        }
        public static bool operator !=(Enumeration<T, TId> first, T second)
        {
            return !(first == second);
        }
        public static T FromId(TId id)
        {
            return AllValues.Where(value => value.Id.Equals(id)).FirstOrDefault();
        }
        public static readonly ReadOnlyCollection<T> AllValues = FindValues();
        private static ReadOnlyCollection<T> FindValues()
        {
            var values =
                (from staticField in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                where staticField.FieldType == typeof(T)
                select (T) staticField.GetValue(null))
                .ToList()
                .AsReadOnly();
            var duplicateIds =
                (from value in values
                group value by value.Id into valuesById
                where valuesById.Skip(1).Any()
                select valuesById.Key)
                .Take(1)
                .ToList();
            if(duplicateIds.Count > 0)
            {
                throw new DuplicateEnumerationIdException("Duplicate ID: " + duplicateIds.Single());
            }
            return values;
        }
        protected Enumeration(TId id, string name)
        {
            Contract.Requires(((object) id) != null);
            Contract.Requires(!String.IsNullOrEmpty(name));
            this.Id = id;
            this.Name = name;
        }
        protected Enumeration()
        {}
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return this.Name;
        }
        #region IEquatable
        public virtual bool Equals(T other)
        {
            return other != null && this.IdComparer.Equals(this.Id, other.Id);
        }
        #endregion
        public virtual TId Id { get; private set; }
        public virtual string Name { get; private set; }
        protected virtual IEqualityComparer<TId> IdComparer
        {
            get { return EqualityComparer<TId>.Default; }
        }
    }
