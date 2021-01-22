    sw = Stopwatch.StartNew();
    total = 0;
    uint bytes = (uint)Marshal.SizeOf(t1.GetType());
    GCHandle handle1 = GCHandle.Alloc(t1, GCHandleType.Pinned);
    IntPtr ptr1 = handle1.AddrOfPinnedObject();
    for (int i = 0; i < 10000000; ++i)
    {
        ShallowCloneTest t2 = new ShallowCloneTest();               // 0.03s
        GCHandle handle2 = GCHandle.Alloc(t2, GCHandleType.Pinned); // 0.75s (+ 'Free' call)
        IntPtr ptr2 = handle2.AddrOfPinnedObject();                 // 0.06s
        memcpy(ptr2, ptr1, new UIntPtr(bytes));                     // 0.17s
        handle2.Free();
        total += t2.Foo;
    }
    handle1.Free();
    Console.WriteLine("Took {0:0.00}s", sw.Elapsed.TotalSeconds);
