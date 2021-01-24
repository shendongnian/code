	public bool deleteItem(Item s)
	{
		bool success = false;
		using (DBEntities cxt = new DecagonDBEntities())
		{
			cxt.Items.Attach(s);
			cxt.Items.Remove(s);              
			int delete = cxt.SaveChanges();
			bool success = delete == 1;
			return success;
		}
	}
