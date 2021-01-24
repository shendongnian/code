    // the input here is a managed C# array
    public IntPtr AllocateNativeArray(CameraInfo[] myArray)
    {
        if (myArray == null || buttons.Count == 0)
            return IntPtr.Zero;
        // building native structures
        var nativeArray = new Aivusdk_CameraInfo[myArray.Length];
        for (int i = 0; i < myArray.Length; i++)
        {
            // TODO: fill properties
        }
        // allocating unmanaged memory and marshaling elements
        int elementSize = Marshal.SizeOf(typeof(Aivusdk_CameraInfo));
        IntPtr result = Marshal.AllocHGlobal(nativeArray.Length * elementSize);
        for (int i = 0; i < nativeArray.Length; i++)
        {
            Marshal.StructureToPtr(nativeArray[i], new IntPtr((long)result + i * elementSize), false);
        }
        return result;
    }
