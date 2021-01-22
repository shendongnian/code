    storage.Commit(0);   // storage is a pointer to IStorage in OP's question
    Marshal.ReleaseComObject(storage);
    storage = null;
    GC.Collect();
    GC.Collect();  // call twice for good measure
    GC.WaitForPendingFinalizers();      
