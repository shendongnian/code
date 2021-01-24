	// Normal pointer to an object.
	int[] a = new int[5] { 10, 20, 30, 40, 50 };
	// Must be in unsafe code to use interior pointers.
	unsafe
	{
		// Must pin object on heap so that it doesn't move while using interior pointers.
		fixed (int* p = &a[0])
		{
			// p is pinned as well as object, so create another pointer to show incrementing it.
			int* p2 = p;
			Console.WriteLine(*p2);
            
            ...more here...
