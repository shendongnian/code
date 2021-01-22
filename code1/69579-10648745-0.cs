			// save groups
			ListViewGroup[] oGroups = new ListViewGroup[list.Groups.Count];
			list.Groups.CopyTo(oGroups, 0);
			list.Groups.Clear();
			// restore groups
			switch (groupSortOrder)
			{
				case SortOrder.Ascending:
					list.Groups.AddRange(oGroups.OrderBy(x => x.Name).ToArray());
					break;
				case SortOrder.Descending:
					list.Groups.AddRange(oGroups.OrderByDescending(x => x.Name).ToArray());
					break;
				default:
					list.Groups.AddRange(oGroups);
					break;
			}
