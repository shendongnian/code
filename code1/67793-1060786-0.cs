    public sealed class WebAgentPermission
    {
        private long ID;
        public static readonly WebAgentPermission
            ViewRuleGroup = new WebAgentPermission { ID = 1 };
        public static readonly WebAgentPermission
            AddRuleGroup  = new WebAgentPermission { ID = 2 };
        private WebAgentPermission() { } 
        // considerations: override equals/gethashcode, probably override tostring,
        // maybe implicit cast to/from long, maybe other stuff
    }
