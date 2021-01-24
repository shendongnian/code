	void Main()
	{
		var input = new[] { "AB-PQ", "PQ-XYZ", "XYZ=CD", "CD-A", "A=XY", "XY-JK" };
		
		var output =
		    input
				.Select(i => new Segment(i))
				.Aggregate(
				    "",
				    (a, x) => a + x.ToString().Substring(a == "" ? 0 : x.Origin.Length));
	}
	
	public enum Mode
	{
		Road, Rail
	}
	
	public sealed class Segment : IEquatable<Segment>
	{
		private readonly string _origin;
		private readonly Mode _mode;
		private readonly string _destination;
	
		public string Origin { get { return _origin; } }
		public Mode Mode { get { return _mode; } }
		public string Destination { get { return _destination; } }
	
		public Segment(string descriptor)
		{
			var parts = descriptor.Split('-', '=');
			if (parts.Length != 2)
			{
				throw new System.ArgumentException("Segment descriptor must contain '=' or '-'.");
			}
			_origin = parts[0];
			_mode = descriptor.Contains("=") ? Mode.Rail : Mode.Road;
			_destination = parts[1];
		}
	
		public Segment(string origin, Mode mode, string destination)
		{
			_origin = origin;
			_mode = mode;
			_destination = destination;
		}
	
		public override bool Equals(object obj)
		{
			if (obj is Segment)
				return Equals((Segment)obj);
			return false;
		}
	
		public bool Equals(Segment obj)
		{
			if (obj == null) return false;
			if (!EqualityComparer<string>.Default.Equals(_origin, obj._origin)) return false;
			if (!EqualityComparer<Mode>.Default.Equals(_mode, obj._mode)) return false;
			if (!EqualityComparer<string>.Default.Equals(_destination, obj._destination)) return false;
			return true;
		}
	
		public override int GetHashCode()
		{
			int hash = 0;
			hash ^= EqualityComparer<string>.Default.GetHashCode(_origin);
			hash ^= EqualityComparer<Mode>.Default.GetHashCode(_mode);
			hash ^= EqualityComparer<string>.Default.GetHashCode(_destination);
			return hash;
		}
	
		public override string ToString()
		{
			return $"{_origin}{(_mode == Mode.Rail ? "=" : "-")}{_destination}";
		}
	
		public static bool operator ==(Segment left, Segment right)
		{
			if (object.ReferenceEquals(left, null))
			{
				return object.ReferenceEquals(right, null);
			}
	
			return left.Equals(right);
		}
	
		public static bool operator !=(Segment left, Segment right)
		{
			return !(left == right);
		}
	}
	
