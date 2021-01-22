    public static T[] GetSubArray<T>(T[] array, Range range)
    {
        if (array == null)
    	{
    		ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
    	}
    	(int Offset, int Length) offsetAndLength = range.GetOffsetAndLength(array.Length);
    	int item = offsetAndLength.Offset;
    	int item2 = offsetAndLength.Length;
    	if (default(T) != null || typeof(T[]) == array.GetType())
    	{
    		if (item2 == 0)
    		{
    			return Array.Empty<T>();
    		}
    		T[] array2 = new T[item2];
    		Buffer.Memmove(ref Unsafe.As<byte, T>(ref array2.GetRawSzArrayData()), ref Unsafe.Add(ref Unsafe.As<byte, T>(ref array.GetRawSzArrayData()), item), (uint)item2);
    		return array2;
    	}
    	T[] array3 = (T[])Array.CreateInstance(array.GetType().GetElementType(), item2);
    	Array.Copy(array, item, array3, 0, item2);
    	return array3;
    }
