    public class TestClass
	{
		private Dictionary<string, List<ShortRef_Control>> tableDictionary;
		public TestClass()
		{
			ReloadCache();
		}
		public List<ShortRef_Control> ShortRefControls
		{
			get
			{
                if (ShouldReload())
				{
					ReloadCache();
				}
				return tableDictionary["refcontrols"];
			}
		}
		public void ReloadCache()
		{
			tableDictionary["refcontrols"] =
			   (from src in dataContext.ShortRef_Controls select src).ToList();
		}
		private bool ShouldReload()
		{
			return tableDictionary["refcontrols"] == null || !tableDictionary["refcontrols"].Any();
		}
	}
