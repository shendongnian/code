	public struct ObjectIniter<TObject>
	{
		public ObjectIniter(TObject obj)
		{
			Obj = obj;
		}
		public TObject Obj { get; }
	}
