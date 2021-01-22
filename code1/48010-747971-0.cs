    /// <summary>
    /// Performs a binary search on a specified EventLogEntryCollection's
    /// TimeWritten property
    /// </summary>
    /// <param name="entries">The collection to search</param>
    /// <param name="value">The timestamp value being searched</param>
    /// <param name="low">The lower-bound search index</param>
    /// <param name="high">The upper-bound search index</param>
    /// <returns>The index of a matching timestamp, or -1 if not found</returns>
    private int BinarySearch(EventLogEntryCollection entries, DateTime value, int low, int high)
    {
    	if (high < low)
    		return -1;
    	int mid = low + ((high - low) / 2);
    	if (entries[mid].TimeWritten > value)
    		return BinarySearch(entries, value, low, mid - 1);
    	else if (entries[mid].TimeWritten < value)
    		return BinarySearch(entries, value, mid + 1, high);
    	else
    		return mid;
    }
