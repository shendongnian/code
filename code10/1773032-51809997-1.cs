	public class Data : Controller
	{
		public void Get(ref string somevariable)
		{
			somevariable = CachedDataProvider.GetData();
		}
	}
	
