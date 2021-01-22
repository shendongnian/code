	///<summary>Adds zero or more items to a collection.</summary>
	public static void AddRange<TItem, TElement>(this ICollection<TElement> collection, IEnumerable<TItem> items)
		where TItem : TElement {
		if (collection == null) throw new ArgumentNullException("collection");
		if (items == null) throw new ArgumentNullException("items");
		foreach (var item in items)
			collection.Add(item);
	}
---
    visibleTasks = new ObservableCollection<MyTasks>();
    visibleTasks.AddRange(filteredResults);
