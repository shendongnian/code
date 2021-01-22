	abstract class Base
	{
		private static Dictionary<Type, string> _registry = new Dictionary<Type, string>();
		protected static void Register(Type t, string constVal)
		{
			_registry.Add(t, constVal);
		}
		protected Base()
		{
			if(!_registry.ContainsKey(this.GetType()))
			throw new NotSupportedException("Type must have a registered constant");
		}
		public string TypeConstant
		{
			get
			{
				return _registry[this.GetType()];
			}
		}
	}
	class GoodSubtype : Base
	{
		static GoodSubtype()
		{
			Base.Register(typeof(GoodSubtype), "Good");
		}
		public GoodSubtype()
			: base()
		{
		}
	}
	class Badsubtype : Base
	{
		public Badsubtype()
			: base()
		{
		}
	}
