	List<FlatItem> flatItems = ...;
	var navigationItems = flatItems.Select(
		i => new NavigationItem { ID = i.ID, Title = i.Title, ParentID = i.ParentID }
	).ToList();
	foreach (var i in navigationItems)
		i.Children = navigationItems.Where(n => n.ParentID == i.ID).ToList();
    // get Google, Microsoft, Oracle items
    var rootNavigationItems = navigationItems.Where(n => n.ParentID == 0);
