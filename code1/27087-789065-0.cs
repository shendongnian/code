    // Measure starting point memory use
    GC_MemoryStart = System.GC.GetTotalMemory(true);
    
    // Allocate a new byte array of 20000 elements (about 20000 bytes)
    MyByteArray = new byte[20000];
    
    // Obtain measurements after creating the new byte[]
    GC_MemoryEnd = System.GC.GetTotalMemory(true);
    
    // Ensure that the Array stays in memory and doesn't get optimized away
    MyByteArray[1] = 20;
