    internal class ControllerContextRegion : IDisposable
    {
        private readonly RouteData routeData;
        private readonly string previousControllerName;
        public ControllerContextRegion(RouteData routeData, string controllerName)
        {
            this.routeData = routeData;
            this.previousControllerName = routeData.GetRequiredString("controller");
            this.SetControllerName(controllerName);
        }
        public void Dispose()
        {
            this.SetControllerName(this.previousControllerName);
        }
        private void SetControllerName(string controllerName)
        {
            this.routeData.Values["controller"] = controllerName;
        }
    }
