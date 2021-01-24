	public static TParent FindParentOf<TParent, TChild>(TChild child)
		where TParent : class
		where TChild : class
	{
		return FindParentOfRecursive(child, typeof(TParent)) as TParent;
	}
	
	private static object FindParentOfRecursive(object child, Type parentType)
	{
		var IEnumType = typeof(IEnumerable);
		var childType = child.GetType();
		
		foreach (var prop in childType.GetProperties()
            .Where(x => x.PropertyType.IsClass && !IEnumType.IsAssignableFrom(x.PropertyType)))
		{
			var parentVal = prop.GetValue(child);
			if (prop.PropertyType == parentType)
				return parentVal;
			else if(parentVal != null)
			{
				var result = FindParentOfRecursive(parentVal, parentType);
				if (result != null)
					return result;
			}
		}
		return null;
	}
