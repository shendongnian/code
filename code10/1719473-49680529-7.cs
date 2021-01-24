    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JsonViewAttribute : Attribute {
        public JsonViewAttribute(string viewName) {
            ViewName = viewName;
        }
        public string ViewName { get; }
    }
