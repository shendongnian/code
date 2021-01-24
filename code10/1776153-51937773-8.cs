    @functions {
        public string GetActionName<T>(string methodName) {
            var controllerType = typeof(T);
            var method = controllerType.GetMethod(methodName);
            var attributeType = typeof(ActionNameAttribute);
            var attribute = method.GetCustomAttributes(attributeType, false)[0];
            return (attribute as ActionNameAttribute).Name;
        }
    }
    <p>@(GetActionName<HomeController>(nameof(HomeController.Contact)))</p>
