	private List<ContextMenuItem> items = new List<ContextMenuItem>();
	[PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public List<ContextMenuItem> Items
	{
		get
		{
			if (items == null)
			{
				items = new List<ContextMenuItem>();
			}
			return items;
		}
		set
		{
			items = value;
		}
	}
