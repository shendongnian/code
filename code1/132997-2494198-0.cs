    Thread.MemoryBarrier();
    var initialMemory = System.GC.GetTotalMemory(true);
    // body
    var somethingThatConsumesMemory = Enumerable.Range(0, 100000)
        .ToArray();
    // end
    Thread.MemoryBarrier();
    var finalMemory = System.GC.GetTotalMemory(true);
    var consumption = finalMemory - initialMemory;
