	public bool deleteItem(Item s)
	{
		bool success = false;
		using (DBEntities cxt = new DecagonDBEntities())
		{
			var itemToDelete = cxt.Items.SingleOrDefault(_ => _.Id == s.Id);
			// validate itemToDelete like check for null etc
			cxt.Items.Remove(itemToDelete);
			int delete = cxt.SaveChanges();
			bool success = delete == 1;
			return success;
		}
	}
