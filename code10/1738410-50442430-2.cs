    // Get the type info for the open type
	Type openGeneric = typeof(WindowsServiceConfiguration<,>);
    // Make a type for a specific value of T
	Type closedGeneric = openGeneric.MakeGenericType(typeof(WindowsServiceJobContainer<SyncMarketCommisionsJob>), typeof(SyncMarketCommisionsJob));
    // Find the desired method
	MethodInfo method = closedGeneric.GetMethod("Create", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
    // Invoke the static method
	method.Invoke(null, new object[0]);
