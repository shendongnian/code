    @functions {
        public string GetActionName(Type controller, string methodName) {
            var method = controller.GetMethod(methodName);
            var attributeType = typeof(ActionNameAttribute);
            var attribute = method.GetCustomAttributes(attributeType, false)[0];
            return (attribute as ActionNameAttribute).Name;
        }
    }
    <p>@GetActionName(typeof(HomeController), nameof(HomeController.Contact))</p>
