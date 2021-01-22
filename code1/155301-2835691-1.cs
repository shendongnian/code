    public static LogLevel Instance { get { return Nested.level; } }
    
    class Nested {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Nested() { }
        internal static readonly LogLevel level = readLogLevelFromFile();
    }
