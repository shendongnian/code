    public class RouteDogToActionAttribute : ActionMethodSelectorAttribute 
    {
        public RequireRequestValueAttribute(string dogType) 
        {
            DogType = dogType;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) 
        {
            return (controllerContext.HttpContext.Request[DogType] != null);
        }
        public string DogType { get; private set; }
    }
