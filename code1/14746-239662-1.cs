	public class Managed
	{
		private Manager _mgr;
		public Manager Mgr
		{
			get { return _mgr ?? (_mgr = new Manager(this)); }
		}
		public string PrivateSetter { get; private set; }
		public Managed()
		{
			PrivateSetter = "Unset";
		}
		public class Manager
		{
			public void SetProperty(string value)
			{
				m.PrivateSetter = value;
			}
			private Managed m;
			public Manager(Managed man)
			{
				m = man;
			}
		}
	}
