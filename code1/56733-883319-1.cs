    public static IEnumerable<T> SelectManyRecursive<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> selector)
    {
    	if (items == null)
    		throw new ArgumentNullException("items");
    	if (selector == null)
    		throw new ArgumentNullException("selector");
    
    	return SelectManyRecursiveInternal(items, selector);
    }
    private static IEnumerable<T> SelectManyRecursiveInternal<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> selector)
    {
    	foreach (T item in items)
    	{
    		yield return item;
    		IEnumerable<T> subitems = selector(item);
    
    		if (subitems != null)
    		{
    			foreach (T subitem in subitems.SelectManyRecursive(selector))
    				yield return subitem;
    		}
    	}
    }
    // sample use, get Text from some TextBoxes in the form
    var strings = form.Controls
                      .SelectManyRecursive(c => c.Controls) // all controls
                      .OfType<TextBox>() // filter by type
                      .Where(c => c.Text.StartWith("P")) // filter by text
                      .Select(c => c.Text);
