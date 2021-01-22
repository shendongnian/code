    /// <summary>
    /// Represents a sink. May refer to different hardware.
    /// </summary>
    public class Sink
    {
        public static IEnumerable<string> GetCurrentIdentifiers() { ... }
        public static Sink GetSinkForIdentifier(string identifier) { ... }
        private Sink() { ... }
    }
