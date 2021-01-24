	public class Data : Controller
	{
        private CachedDataProvider dataProvider;
		public Data(CachedDataProvider dataProvider)
		{
            this.dataProvider = dataProvider;
		}
	
		public void Get(ref string somevariable)
		{
			somevariable = this.dataProvider.GetData();
		}
	}
	
