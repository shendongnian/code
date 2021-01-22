    public abstract class DataClass : IEquatable<DataClass>
    {
        public override bool Equals(object obj)
        {
            var other = obj as DataClass;
            return this.Equals(other);
        }
        public bool Equals(DataClass other)
        {
            return (!ReferenceEquals(null, other))
                && this.Execute((self2, other2) =>
                    other2.Execute((other3, self3) => self3.Equals(other3), self2)
                    , other);
        }
        public override int GetHashCode()
        {
            return this.Execute(obj => obj.GetHashCode());
        }
        public override string ToString()
        {
            return this.Execute(obj => obj.ToString());
        }
        private TOutput Execute<TOutput>(Func<object, TOutput> function)
        {
            return this.Execute((obj, other) => function(obj), new object());
        }
        protected abstract TOutput Execute<TParameter, TOutput>(
            Func<object, TParameter, TOutput> function,
            TParameter other);
    }
