	partial class Cls
	{
		static Cls()
		{
			UnboundGet = create<Func<Cls, int>>(null, mi_get);
			UnboundSet = create<Action<Cls, int>>(null, mi_set);
		}
		public Cls()
		{
			BoundGet = create<Func<int>>(this, mi_get);
			BoundSet = create<Action<int>>(this, mi_set);
		}
		public readonly static Func<Cls, int> UnboundGet;
		public readonly static Action<Cls, int> UnboundSet;
		public readonly Func<int> BoundGet;
		public readonly Action<int> BoundSet;
		public int Value { get; set; }
	};
