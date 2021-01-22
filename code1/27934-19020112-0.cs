    public class MultipleButtonActionAttribute : ActionNameSelectorAttribute
    {        
        private readonly List<string> AcceptedButtonNames;
        public MultipleButtonActionAttribute(params string[] acceptedButtonNames)
        {
            AcceptedButtonNames = acceptedButtonNames.ToList();
        }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {            
            foreach (var acceptedButtonName in AcceptedButtonNames)
            {
                var button = controllerContext.Controller.ValueProvider.GetValue(acceptedButtonName);
                if (button == null)
                {
                    continue;
                }                
                controllerContext.Controller.ControllerContext.RouteData.Values.Add("ButtonName", acceptedButtonName);
                return true;
            }
            return false;
        }
    }
