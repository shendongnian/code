      System.Guid guid = System.Guid.NewGuid();
        byte[] guidArray = guid.ToByteArray();
    
        // condition
        System.Diagnostics.Debug.Assert(guidArray.Length % sizeof(int) == 0);
    
        int[] intArray = new int[guidArray.Length / sizeof(int)];
    
        System.Buffer.BlockCopy(guidArray, 0, intArray, 0, guidArray.Length);
    
    
        byte[] guidOutArray = new byte[guidArray.Length];
    
        System.Buffer.BlockCopy(intArray, 0, guidOutArray, 0, guidOutArray.Length);
    
        System.Guid guidOut = new System.Guid(guidOutArray);
    
        // check
        System.Diagnostics.Debug.Assert(guidOut == guid);
