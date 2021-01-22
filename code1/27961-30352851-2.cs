    public class SubmitButtonSelector : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public override bool IsValidName(ControllerContext controllerContext, string actionName, System.Reflection.MethodInfo methodInfo)
            {
                // Try to find out if the name exists in the data sent from form
    var value = controllerContext.Controller.ValueProvider.GetValue(Name);
                if (value != null)
                {
                    return true;
                }
                return false;
    
            }
        }
