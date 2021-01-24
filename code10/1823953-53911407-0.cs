	public class BusinessClass
	{
		private static readonly object oLock = new object();
		static BusinessClass myClass { get; set; } = null;
		Repository repo;
		public BusinessClass()
		{
			if (repo == null)
				repo = new RepositoryClass();
		}
		public static BusinessClass Instance
		{
			get
			{
				if myClass == null)
				{
					lock (oLock)
					{
						if myClass == null)
							myClass = new BusinessClass();
					}
				}
				return myClass	
		    }
		}
		public void Update(Entity Item)
		{
			repo.Update(Item);
		}
	}
