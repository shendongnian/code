    public static class ControllerContextExtension
        {
            /// <summary>
            /// BaseController
            /// </summary>
            /// <param name="view"></param>
            /// <returns></returns>
    
            public static BaseController BaseController(this ControllerContext view)
            {
                var factory = CreateControllerFactory();
                return factory.CreateController(view) as BaseController;
            }
            private static DefaultControllerFactory CreateControllerFactory()
            {
                var propertyActivators = new IControllerPropertyActivator[]
                {
                      new DefaultControllerPropertyActivator(),
                };
    
                return new DefaultControllerFactory(
                    new DefaultControllerActivator(new TypeActivatorCache()),
                    propertyActivators);
            }
        }
