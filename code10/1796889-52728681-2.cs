        public class CustomControllerFactory : DefaultControllerFactory {
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
                if (controllerType == typeof(StudentController)) {
                    return new StudentController(new StudentRepository());
                }
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
