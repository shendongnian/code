	public enum GBFEvents
	{
		NONE = 0,
		InitGBFSQL = 1 << 0,
		ServiceIISControlDown = 1 << 1,
		SetWebConfigValues = 1 << 2,
		ReadFilelists = 1 << 3,
		CopyFiles = 1 << 4,
		FixWebConfigValues = 1 << 5,
		BuildAppPaths = 1 << 6,
		PerformDatabaseUpdate = 1 << 7,
		ServiceIISControlUp = 1 << 8,
        /* Helpers */
		AllDBEvents = InitGBFSQL | PerformDatabaseUpdate,
		AllServiceEvents = ServiceIISControlDown | ServiceIISControlUp,
		AllConfigEvents = SetWebConfigValues | FixWebConfigValues,
		AllFileEvents = ReadFilelists | CopyFiles | BuildAppPaths,
		All = AllDBEvents | AllServiceEvents | AllConfigEvents | AllFileEvents
	}
