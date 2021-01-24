    public class Diagnostics
    {
        public String VersionNumber { get; set; }
        [RequireRoleView("admin")]
        public Boolean ViewIfAdmin => true;
        [RequireRoleView("hr")]
        public Boolean ViewIfHr => true;
        [RequireRoleView("hr", "admin")]
        public Boolean ViewIfHrOrAdmin => true;
    }
    
