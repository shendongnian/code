        static void Main(string[] args)
        {
            // implicit conversion here from Customer to Conductor<Customer>
            Conductor<Customer> conductor = DataConcierge.Create<Customer>(123);
            if (conductor.HasValue)
            {
                Console.WriteLine("I got a customer with Id {0}!", conductor.Value.Id);
                // implicit conversion here from Conductor<Customer> to Customer[]
                DataConcierge.Save<Customer>(conductor);
            }
        }
    public struct Conductor<T> : IConductor<T>, IEquatable<T>, IEquatable<Conductor<T>>, IEquatable<IConductor<T>>
    {
        private T _Value;
        public Conductor(T value)
        {
            this._Value = value;
        }
        public T Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }
        public bool HasValue
        {
            get { return this._Value != null; }
        }
        public T GetValueOrDefault()
        {
            if (this.HasValue)
                return this.Value;
            else
                return default(T);
        }
        public T GetValueOrDefault(T @default)
        {
            if (this.HasValue)
                return this.Value;
            else
                return @default;
        }
        public bool TryGetValue(out T value)
        {
            if (this.HasValue)
            {
                value = this.Value;
                return true;
            }
            else
            {
                value = default(T);
                return false;
            }
        }
        public T[] AsArray()
        {
            return new T[] { this._Value };
        }
        public static implicit operator Conductor<T>(T value)
        {
            return new Conductor<T>(value);
        }
        public static implicit operator T(Conductor<T> conductor)
        {
            return conductor.Value;
        }
        public static implicit operator T[](Conductor<T> conductor)
        {
            return conductor.AsArray();
        }
        public bool Equals(T other)
        {
            var otherEquatable = other as IEquatable<T>;
            if (otherEquatable != null)
                return otherEquatable.Equals(this.Value);
            else
                return object.Equals(this.Value, other);
        }
        public bool Equals(Conductor<T> other)
        {
            if (other.HasValue)
                return this.Equals(other.Value);
            else
                return !this.HasValue;
        }
        public bool Equals(IConductor<T> other)
        {
            if (other != null && other.HasValue)
                return this.Equals(other.Value);
            else
                return !this.HasValue;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return !this.HasValue;
            var conductor = obj as IConductor<T>;
            if (conductor != null)
            {
                if (conductor.HasValue)
                    return this.Equals(conductor.Value);
                else
                    return !this.HasValue;
            }
            return object.Equals(this.Value, obj);
        }
        public override int GetHashCode()
        {
            if (this.HasValue)
                return this.Value.GetHashCode();
            else
                return 0;
        }
        public override string ToString()
        {
            if (this.HasValue)
                return this.Value.ToString();
            else
                return null;
        }
    }
