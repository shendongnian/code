	public static class EntityExtensions
	{
		public static void EnsureLoaded(this RelatedEnd relatedEnd)
		{
			if (!relatedEnd.IsLoaded)
				relatedEnd.Load();
		}
	}
