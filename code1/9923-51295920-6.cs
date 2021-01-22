    #pragma warning disable CS0660, CS0661, CS0659
    
	// Composition is a proxy for another class T which it composes in it's Value property
	// it forwards Equals, ==, !=, GetHashCode(), ToString() to Value and serialize to Json via Value
	// when inheriting you still need to define ==, !=, and Equals(Derived) to call base
	public abstract class Composition<T> {
		protected Composition(T value) => Value = value;
		public readonly T Value;
		public override bool Equals(object obj) { var o = obj as Composition<T>; return o is null ? false : Value.Equals(o.Value); }
		public override int GetHashCode() => IsNull() ? 0 : Value.GetHashCode();
		public override string ToString() => IsNull() ? string.Empty : Value.ToString();
		protected bool IsNull() => (Nullable.GetUnderlyingType(typeof(T)) != null) ? EqualityComparer<T>.Default.Equals(Value, default) : false;
	}
