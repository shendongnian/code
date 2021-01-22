    unsafe
    {
        double[][] array = new double[3][];
        array[0] = new double[] { 1.25, 2.28, 3, 4 };
        array[1] = new double[] { 5, 6.24, 7.42, 8 };
        array[2] = new double[] { 9, 10.15, 11, 12.14 };
        
        GCHandle[] pinnedArray = new GCHandle[array.Length];
 
        for (int i = 0; i < array.Length; i++)
        {
            pinnedArray[i] = GCHandle.Alloc(array[i], GCHandleType.Pinned);
        }
        for (int i = 0; i < array.Length; ++i)
        {
            // as you can see, this pointer will point to the first element of each array
            double* jaggedArray = (double*)pinnedArray[i].AddrOfPinnedObject();
            Console.WriteLine(*(jaggedArray));
        }
        // unpin all the pinned objects,
        // otherwise they will live in memory till assembly unloading
        // even after they go out of scope
        for (int i = 0; i < pinnedArray.Length; ++i)
            pinnedArray[i].Free();
    }
