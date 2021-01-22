    public static bool isDebugging() {
        bool debugging = false;
			
        WellAreWe(ref debugging);
        return debugging;
    }
    [Conditional("DEBUG")]
    private static void WellAreWe(ref bool debugging)
    {
        debugging = true;
    }
