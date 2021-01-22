	public struct Money : IComparable
	{
		private readonly long _value;
		public const long Multiplier = 1000000;
		private const decimal ReverseMultiplier = 0.000001m;
		public Money(long value)
		{
			_value = value;
		}
		public static explicit operator Money(decimal d)
		{
			return new Money(Decimal.ToInt64(d * Multiplier));
		}
		public static implicit operator decimal (Money m)
		{
			return m._value * ReverseMultiplier;
		}
		public static explicit operator Money(double d)
		{
			return new Money(Convert.ToInt64(d * Multiplier));
		}
		public static explicit operator double (Money m)
		{
			return Convert.ToDouble(m._value * ReverseMultiplier);
		}
		public static bool operator ==(Money m1, Money m2)
		{
			return m1._value == m2._value;
		}
		public static bool operator !=(Money m1, Money m2)
		{
			return m1._value != m2._value;
		}
		public static Money operator +(Money d1, Money d2)
		{
			return new Money(d1._value + d2._value);
		}
		public static Money operator -(Money d1, Money d2)
		{
			return new Money(d1._value - d2._value);
		}
		public static Money operator *(Money d1, Money d2)
		{
			return new Money(d1._value * d2._value / Multiplier);
		}
		public static Money operator /(Money d1, Money d2)
		{
			return new Money(d1._value / d2._value * Multiplier);
		}
		public static bool operator <(Money d1, Money d2)
		{
			return d1._value < d2._value;
		}
		public static bool operator <=(Money d1, Money d2)
		{
			return d1._value <= d2._value;
		}
		public static bool operator >(Money d1, Money d2)
		{
			return d1._value > d2._value;
		}
		public static bool operator >=(Money d1, Money d2)
		{
			return d1._value >= d2._value;
		}
		public override bool Equals(object o)
		{
			if (!(o is Money))
				return false;
			return this == (Money)o;
		}
		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}
		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;
			if (!(obj is Money))
				throw new ArgumentException("Cannot compare money.");
			Money other = (Money)obj;
			return _value.CompareTo(other._value);
		}
		public override string ToString()
		{
			return ((decimal) this).ToString(CultureInfo.InvariantCulture);
		}
	}
