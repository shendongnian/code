	public partial class DrawerControl : UserControl
	{
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public PlaceHolder BodyContent { get; set; }
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public PlaceHolder GripContent { get; set; }
	}
