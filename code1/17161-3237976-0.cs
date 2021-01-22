    // This file contains extension methods for generic List<> class to operate on sorted lists.
    // Duplicate values are OK.
    // O(ln(n)) is still much faster then the O(n) of LINQ's searches/filters.
    static partial class SortedList
    {
    	// Return the index of the first element with the key greater then provided.
    	// If there's no such element within the provided range, it returns iAfterLast.
    	public static int sortedFirstGreaterIndex<tElt, tKey>( this IList<tElt> list, Func<tElt, tKey, int> comparer, tKey key, int iFirst, int iAfterLast )
    	{
    		if( iFirst < 0 || iAfterLast < 0 || iFirst > list.Count || iAfterLast > list.Count )
    			throw new IndexOutOfRangeException();
    		if( iFirst > iAfterLast )
    			throw new ArgumentException();
    		if( iFirst == iAfterLast )
    			return iAfterLast;
    
    		int low = iFirst, high = iAfterLast;
    		// The code below is inspired by the following article:
    		// http://en.wikipedia.org/wiki/Binary_search#Single_comparison_per_iteration
    		while( low < high )
    		{
    			int mid = ( high + low ) / 2;
    			// 'mid' might be 'iFirst' in case 'iFirst+1 == iAfterLast'.
    			// 'mid' will never be 'iAfterLast'.
    			if( comparer( list[ mid ], key ) <= 0 )	// "<=" since we gonna find the first "greater" element
    				low = mid + 1;
    			else
    				high = mid;
    		}
    		return low;
    	}
    
    	// Return the index of the first element with the key greater then the provided key.
    	// If there's no such element, returns list.Count.
    	public static int sortedFirstGreaterIndex<tElt, tKey>( this IList<tElt> list, Func<tElt, tKey, int> comparer, tKey key )
    	{
    		return list.sortedFirstGreaterIndex( comparer, key, 0, list.Count );
    	}
    
    	// Add an element to the sorted array.
    	// This could be an expensive operation if frequently adding elements that sort firstly.
    	// This is cheap operation when adding elements that sort near the tail of the list.
    	public static int sortedAdd<tElt>( this List<tElt> list, Func<tElt, tElt, int> comparer, tElt elt )
    	{
    		if( list.Count == 0 || comparer( list[ list.Count - 1 ], elt ) <= 0 )
    		{
    			// either the list is empty, or the item is greater then all elements already in the collection.
    			list.Add( elt );
    			return list.Count - 1;
    		}
    		int ind = list.sortedFirstGreaterIndex( comparer, elt );
    		list.Insert( ind, elt );
    		return ind;
    	}
    
    	// Find first exactly equal element, return -1 if not found.
    	public static int sortedFindFirstIndex<tElt, tKey>( this List<tElt> list, Func<tElt, tKey, int> comparer, tKey elt )
    	{
    		int low = 0, high = list.Count - 1;
    
    		while( low < high )
    		{
    			int mid = ( high + low ) / 2;
    			if( comparer( list[ mid ], elt ) < 0 )
    				low = mid + 1;
    			else
    				high = mid; // this includes the case when we've found an element exactly matching the key
    		}
    		if( high >= 0 && 0 == comparer( list[ high ], elt ) )
    			return high;
    		return -1;
    	}
    
    	// Return the IEnumerable that returns array elements in the reverse order.
    	public static IEnumerable<tElt> sortedReverse<tElt>( this List<tElt> list )
    	{
    		for( int i=list.Count - 1; i >= 0; i-- )
    			yield return list[ i ];
    	}
    }
