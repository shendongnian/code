	public static class GenericLimit<T>
	{
		public static readonly T MinValue = (T)MinValue.GetType ().GetField ("MinValue").GetValue (MinValue);
		public static readonly T MaxValue = (T)MaxValue.GetType ().GetField ("MaxValue").GetValue (MaxValue);
	}
	public class MinMax<T> where T : struct
	{
		private readonly T minValue = GenericLimit<T>.MinValue;
		private readonly T maxValue = GenericLimit<T>.MaxValue;
		public T Min { get; private set; }
		public T Max { get; private set; }
		public T Length {get {return (Operator.Subtract (Max, Min));}}
		public static bool InRange (T value, T min, T max)
		{
			return (Operator.GreaterThanOrEqual (value, min) && Operator.LessThanOrEqual (value, max));
		}
		public MinMax ()
		{
			Reset ();
		}
		
		public void Update (T n)
		{
			if (Operator.LessThan (n, Min)) Min = n;
			if (Operator.GreaterThan (n, Max)) Max = n;
		}
		
		public void Reset ()
		{
			Min = maxValue;
			Max = minValue;
		}
		
		public T Normalize (T n)
		{
			n = Operator.Subtract (n, Min);
			return (Operator.Divide (n, Length));
		}
	}
