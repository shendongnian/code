    [RequireRequestValue("someInt")]
    public ActionResult MyMethod(int someInt) { /* ... */ }
    
    [RequireRequestValue("someString")]
    public ActionResult MyMethod(string someString) { /* ... */ }
    
    public class RequireRequestValueAttribute : ActionMethodSelectorAttribute {
        public RequireRequestValueAttribute(string valueName) {
            ValueName = valueName;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) {
            return (controllerContext.HttpContext.Request[ValueName] != null);
        }
        public string ValueName { get; private set; }
    }
