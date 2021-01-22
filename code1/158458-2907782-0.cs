    public static class ArrayHelp {
    	public static void addElement<T>(ref T[] array, T elementToAdd)
    	{
    		Array.Resize(ref array, array.Length + 1);
    		array[array.Length - 1] = elementToAdd;
    	}
    }
