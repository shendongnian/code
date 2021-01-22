	public class RestrictedRouteCollection : RouteCollection
	{
		public Boolean EnableRestrictions { get; set; }
		protected override void InsertItem(Int32 index, RouteBase item)
		{
			if (EnableRestrictions) { throw new Exception("Unexpected route added".); }
			base.InsertItem(index, item);
		}
		protected override void SetItem(Int32 index, RouteBase item)
		{
			if (EnableRestrictions) { throw new Exception("Unexpected change of RouteCollection item."); }
			base.SetItem(index, item);
		}
		protected override void RemoveItem(Int32 index)
		{
			if (EnableRestrictions)	{ throw new Exception("Unexpected removal from RouteCollection, index: " + index); }
			base.RemoveItem(index);
		}
		protected override void ClearItems()
		{
			if (EnableRestrictions)	{ throw new Exception("Unexpected clearing of routecollection."); }
			base.ClearItems();
		}
	}
