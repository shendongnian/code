	public class ItemModel : RealmObject
	{
		public ItemModel() { }
		public ItemModel(int ID)
		{
			this.ID = ID;
		}
		[PrimaryKey]
		public int ID { get; set; }
		public static ItemModel Create()
		{
			ItemModel NewItemModel()
			{
				var q = Realm.GetInstance(Consts.realmDBName).All<ItemModel>();
				return new ItemModel(q.Any() ? q.Last().ID + 1 : 0);
			}
			if (Realm.GetInstance(Consts.realmDBName).IsInTransaction)
			{
				return NewItemModel();
			}
			// Use a pseudo transaction to ensure multi-process safety on obtaining the last record 
			using (var trans = Realm.GetInstance(Consts.realmDBName).BeginWrite())
			{
				return NewItemModel();
			}
		}
	}
