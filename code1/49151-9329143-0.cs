    public class Color
    {
        private Color()
        {
        }
        public string Name { get; private set; }
        public int Prop2 { get; private set; }
        public class Builder : Builder<Color>
        {
            public Builder()
            {
                // possible
                _instance.Name = "SomeDefaultValue";
            }
        }
    }
    class Builder<T> : IEnumerable<string>
    {
        protected T _instance = Activator.CreateInstance(typeof(T));
        public void Add<TProperty>(Expression<Func<T, TProperty>> prop, TProperty value)
        {
            StaticReflection.GetPropertyInfo(prop).SetValue(_instance, value, null);
        }
        public static implicit operator T(Builder<T> builder)
        {
            return builder.Build();
        }
        public T Build()
        {
            return _instance;
        }
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            // e.g. return iterator over the property names
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)this).GetEnumerator();
        }
    }
