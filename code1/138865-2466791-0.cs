        // Create a collection of type CounterCreationDataCollection.
    System.Diagnostics.CounterCreationDataCollection CounterDatas = 
       new System.Diagnostics.CounterCreationDataCollection();
    // Create the counters and set their properties.
    System.Diagnostics.CounterCreationData cdCounter1 = 
       new System.Diagnostics.CounterCreationData();
    System.Diagnostics.CounterCreationData cdCounter2 = 
       new System.Diagnostics.CounterCreationData();
    cdCounter1.CounterName = "Counter1";
    cdCounter1.CounterHelp = "help string1";
    cdCounter1.CounterType = System.Diagnostics.PerformanceCounterType.NumberOfItems64;
    cdCounter2.CounterName = "Counter2";
    cdCounter2.CounterHelp = "help string 2";
    cdCounter2.CounterType = System.Diagnostics.PerformanceCounterType.NumberOfItems64;
    // Add both counters to the collection.
    CounterDatas.Add(cdCounter1);
    CounterDatas.Add(cdCounter2);
    // Create the category and pass the collection to it.
    System.Diagnostics.PerformanceCounterCategory.Create(
       "Multi Counter Category", "Category help", CounterDatas);
