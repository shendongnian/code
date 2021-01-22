    public class NamedInt : IComparable<int>, IEquatable<int>
	{
		internal int Value { get; }
		protected NamedInt() { }
		protected NamedInt(int val) { Value = val; }
		protected NamedInt(string val) { Value = Convert.ToInt32(val); }
		public static implicit operator int (NamedInt val) { return val.Value; }
		public static bool operator ==(NamedInt a, int b) { return a?.Value == b; }
		public static bool operator ==(NamedInt a, NamedInt b) { return a?.Value == b?.Value; }
		public static bool operator !=(NamedInt a, int b) { return !(a==b); }
		public static bool operator !=(NamedInt a, NamedInt b) { return !(a==b); }
		public bool Equals(int other) { return Equals(new NamedInt(other)); }
		public override bool Equals(object other) {
			if ((other.GetType() != GetType() && other.GetType() != typeof(string))) return false;
			return Equals(new NamedInt(other.ToString()));
		}
		private bool Equals(NamedInt other) {
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(Value, other.Value);
		}
		public int CompareTo(int other) { return Value - other; }
		public int CompareTo(NamedInt other) { return Value - other.Value; }
		public override int GetHashCode() { return Value.GetHashCode(); }
		public override string ToString() { return Value.ToString(); }
	}
