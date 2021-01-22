	public class VirtualPageMap : SubClassMap<VirtualPage>
	{
		public VirtualPageMap()
		{
			Map(x => x.ParentId);
			Map(x => x.PageName);
			Map(x => x.Title);
			Map(x => x.Body);
			Map(x => x.ViewName);
			Map(x => x.ViewData).Length(4001); // anything over 4000 is nvarchar(max)
		}
	}
