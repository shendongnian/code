    public class Program
	{
		public static void Main(string[] args)
		{
			DateTime now = DateTime.Now;
			var myDate = new Int32BackedDate(now.Ticks);
			Console.WriteLine(now);
			Console.WriteLine(myDate.Date);
		}
	}
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct Int32BackedDate
	{
		[FieldOffset(4)]
		private readonly int _high;
		[FieldOffset(0)]
		private readonly int _low;
		[FieldOffset(0)]
		private readonly DateTime _date;
		public DateTime Date { get { return _date; } }
		public Int32BackedDate(long ticks)
		{
			_date = default(DateTime);
			byte[] bytes = BitConverter.GetBytes(ticks);
			_low = BitConverter.ToInt32(bytes, 0);
			_high = BitConverter.ToInt32(bytes, 4);
		}
	}
