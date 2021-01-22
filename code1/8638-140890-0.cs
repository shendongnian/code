        public class ShellController : ControllerBase, IShellController
        {
            public ShellController([StateDependency("State")] StateValue<ShuttleState> state,
                                   [ServiceDependency] IHttpContextLocatorService contextLocator,
                                   [ServiceDependency] IAuthorizationService authService)
                : base(state, contextLocator, authService)
            {
                // code goes here
            }
    }
