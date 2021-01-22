    /// <summary>
    /// Moves the item to the front of the list if it exists, if it does not it returns false
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool MoveToFrontOfListWhere<T>(this List<T> collection, Func<T, bool> predicate)
    {
    	if (collection == null || collection.Count <= 0) return false;
    
    	int index = -1;
    	for (int i = 0; i < collection.Count; i++)
    	{
    		T element = collection.ElementAt(i);
    		if (!predicate(element)) continue;
    		index = i;
    		break;
    	}
    
    	if (index == -1) return false;
    
    	T item = collection[index];
    	collection[index] = collection[0];
    	collection[0] = item;
    	return true;
    }
