     this.GetDecendantsFromList(parent, items);
     private void GetDecendantsFromList(ItemInfo parent, List<ItemInfo> items)
		{
			parent.Children = items.Where(a => a.ParentId == parent.Id).ToList();
			foreach (var child in parent.Children)
			{
				this.GetDecendantsFromList(child,items);
			}
		}
