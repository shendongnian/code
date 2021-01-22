    interface IOptionalStop
	{
		Action Stop { get; }
	}
	public class WithStop : IOptionalStop
	{
		#region IOptionalStop Members
		public Action Stop
		{
			get;
			private set;
		}
		#endregion
		public WithStop()
		{
			this.Stop =
				delegate
				{
					// we are going to stop, honest!
				};
		}
	}
	public class WithoutStop : IOptionalStop
	{
		#region IOptionalStop Members
		public Action Stop
		{
			get;
			private set;
		}
		#endregion
	}
    public class Program
    {
		public static string Text { get; set; }
        public static void Main(string[] args)
        {
			var a = new WithStop();
			a.Stop();
			var o = new WithoutStop();
			// Stop is null and we cannot actually call it
			a.Stop();
        }
    }
