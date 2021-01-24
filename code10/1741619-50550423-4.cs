    // Lets start from a collect
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("Memory used before collection:       {0:N0}", GC.GetTotalMemory(false));
    
    // create a class/viewmodel
    var gcCollectClass = new MyGCCollectClass();
    
    // create a world of garbage
    // return back a list that is part of the class
    var list = gcCollectClass.Main();
    
    // lets see whats GC has
    Console.WriteLine("Memory used: {0:N0}", GC.GetTotalMemory(true));
    
    // make sure our garbage is still alive
    Console.WriteLine(gcCollectClass.Garbage.Count);
    
    // Kill the original class
    gcCollectClass = null;
    
    // Force a collection
    GC.Collect();
    GC.WaitForPendingFinalizers();
    
    // double check the list is still alive
    Console.WriteLine(list.Count);
    // Lets make sure we havent caused a memory leak
    Console.WriteLine("Memory used after full collection:   {0:N0}", 
    GC.GetTotalMemory(true));
