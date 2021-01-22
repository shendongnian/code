    static int GetIndex(IList<Item> list, Item value)
    {
        for (int index = 0; index < list.Count; index++)
        {
    	    if (list[index] == value)
    	    {
    	         return index;
    	    } 
        }
        return -1;
    }
