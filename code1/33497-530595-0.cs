    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static void Resize<T>(ref T[] array, int newSize)
    {
        if (newSize < 0)
        {
            throw new ArgumentOutOfRangeException("newSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
        }
        T[] sourceArray = array;
        if (sourceArray == null)
        {
            array = new T[newSize];
        }
        else if (sourceArray.Length != newSize)
        {
            T[] destinationArray = new T[newSize];
            Copy(sourceArray, 0, destinationArray, 0, (sourceArray.Length > newSize) ? newSize : sourceArray.Length);
            array = destinationArray;
        }
    }
 
