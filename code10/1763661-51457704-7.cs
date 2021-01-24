	var inst = new SomeClass();
	var weakRef = new WeakReference<Action>(inst.DoSomething);
	GC.Collect();
    GC.WaitForPendingFinalizers(); // You should do this after forcing a GC, just in case there is still GC work being done in the background.
	Console.WriteLine($"inst is alive = {inst != null} : weakRef.Target is alive = {weakRef.TryGetTarget(out Action callback1)}");
    // These next 2 lines discard local variables, as Hans points out in the comments,  
    // DO NOT do this in production code.  Please read the link he posted for more details.
	inst = null; // discard the class instance
	callback1 = null; // discard the temporary Action instance from TryGetTarget, otherwise it will act as a GC Root, preventing it from being collected later.
	GC.Collect();
    GC.WaitForPendingFinalizers();
	Console.WriteLine($"inst is alive = {inst != null} : weakRef.Target is alive = {weakRef.TryGetTarget(out Action callback2)}");
