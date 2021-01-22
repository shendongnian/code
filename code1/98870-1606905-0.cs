	[Guid("ae9e84b5-3e2d-457e-8fcd-5bbd2a8b832e"), ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	interface nsICacheSession
	{
		void set_doomEntriesIfExpired([In, MarshalAs(UnmanagedType.Bool)] ref bool enabled);
		bool get_doomEntriesIfExpired();
