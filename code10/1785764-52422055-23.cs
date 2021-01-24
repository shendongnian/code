	public abstract class Shim<TImpl>
	{
		internal TImpl It { get; }
		protected Shim(TImpl it) { It = it; }
	}
