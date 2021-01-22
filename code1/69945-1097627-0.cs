    Assembly a = Assembly.GetExecutingAssembly();
    _PerfCounter = new PerformanceCounter(".NET CLR Memory",
                                          "# Bytes in all Heaps",
                                          a.GetName().Name,
                                          true);
