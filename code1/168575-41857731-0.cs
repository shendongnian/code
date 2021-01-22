    // Version.cs
    public static class MyAppVersion
    {
        //build
        public static string Number = "1.0";
        public static string Phase = "Alpha";
        //configuration (these are the build constants I use, substitute your own)
    #if BUILD_SHIPPING
    	public static string Configuration = "Shipping";
    #elif BUILD_DEVELOPMENT
    	public static string Configuration = "Development";
    #elif BUILD_DEBUG
    	public static string Configuration = "Debug";
    #else
    	"build type not defined"
    #endif
    }
