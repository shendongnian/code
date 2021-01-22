    public void ProcessLists<ItemType>(Func<int, IEnumerable<ItemType>> Loader) whereItemType : CommonBase, new() {
	List<string> items = new List<string>();
	IList<ItemType> currentItems = Loader(project.ID).ToList();
	if (currentItems != null) {
		foreach (var existingItem in currentItems) {
			if (items.Contains(existingItem.Name))
				items.Remove(existingItem.Name);
			else
				existingItem.Delete(Services.UserServices.User);
		}
		foreach (string item in items) {
			ItemType item = new ItemType();
			item.Project = project
			item.Name = item.ToString();
			item.Save();
		}
	}
