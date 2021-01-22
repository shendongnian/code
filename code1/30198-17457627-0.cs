    WeakReference w = CodeThatShouldNotMemoryLeak();
    Assert.IsTrue(w.IsAlive);
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Assert.IsFalse(w.IsAlive);
