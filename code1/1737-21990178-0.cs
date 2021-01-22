	public abstract class EnumValidator<TEnum> where TEnum : struct, IConvertible
	{
		protected static bool IsContiguous
		{
			get
			{
				int[] enumVals = Enum.GetValues(typeof(TEnum)).Cast<int>().ToArray();
				int lowest = enumVals.OrderBy(i => i).First();
				int highest = enumVals.OrderByDescending(i => i).First();
				return !Enumerable.Range(lowest, highest).Except(enumVals).Any();
			}
		}
		public static EnumValidator<TEnum> Create()
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new ArgumentException("Please use an enum!");
			}
			return IsContiguous ? (EnumValidator<TEnum>)new ContiguousEnumValidator<TEnum>() : new JumbledEnumValidator<TEnum>();
		}
		public abstract bool IsValid(int value);
	}
	public class JumbledEnumValidator<TEnum> : EnumValidator<TEnum> where TEnum : struct, IConvertible
	{
		private readonly int[] _values;
		public JumbledEnumValidator()
		{
			_values = Enum.GetValues(typeof (TEnum)).Cast<int>().ToArray();
		}
		public override bool IsValid(int value)
		{
			return _values.Contains(value);
		}
	}
	public class ContiguousEnumValidator<TEnum> : EnumValidator<TEnum> where TEnum : struct, IConvertible
	{
		private readonly int _highest;
		private readonly int _lowest;
		public ContiguousEnumValidator()
		{
			List<int> enumVals = Enum.GetValues(typeof (TEnum)).Cast<int>().ToList();
			_lowest = enumVals.OrderBy(i => i).First();
			_highest = enumVals.OrderByDescending(i => i).First();
		}
		public override bool IsValid(int value)
		{
			return value >= _lowest && value <= _highest;
		}
	}
