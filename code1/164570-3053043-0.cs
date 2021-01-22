	public MyClass
	{
		public MyClass Parent;
		
		private List<MyClass> children;
		public ReadOnlyCollection<MyClass> Children
		{
			get { return children.AsReadOnly(); }
		}
	}
