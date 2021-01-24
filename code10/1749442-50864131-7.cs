    public static class ExtensionMethods
	{
		public static IEnumerable<FlatData> GetDescendents(this IEnumerable<FlatData> This, int rootId)
		{
			var rootItem = This.Single( x => x.Id == rootId );
			var queue = new Queue<FlatData>( new [] { rootItem } );
			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				yield return item;
				foreach (var child in This.Where( x => x.ParentId == item.Id )) 
				{
					queue.Enqueue(child);
				}
			}
		}
	}
