    public static void InsertInArray(ref char[] array, char element, int pos)
	{
		// Check that index is inside the bounds
		if (pos < 0 || pos > array.Length)
		{
			throw new IndexOutOfRangeException();
		}
		
		// Resize the array
		Array.Resize(ref array, array.Length + 1);
		
		// Shift elements one place to the right, to make room to new element
		for (int i = array.Length - 1; i > pos; i--)
		{
    		array[i] = array[i-1];
		}
		
		// Set new element
		array[pos] = element;
	}
