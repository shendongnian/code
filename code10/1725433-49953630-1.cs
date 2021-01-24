    public sealed class SecurityContext : ISecurityContext
    {
        // Just get/set with a private backing field. No ambient state
        public Database Database { get; set; }
    }
