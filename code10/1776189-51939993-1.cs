	public abstract class MBData<P, C>
		where P : MBDatas<P, C>
		where C : MBData<P, C>
	{
		public P Parent { get; set; }
	}
	
	public abstract class MBDatas<P, C> : List<C>
		where P : MBDatas<P, C>
		where C : MBData<P, C>
	{ }
