    public class PermissionManagerHandler : IHandlerSelector
    {
         public bool HasOpinionAbout(string key, Type service)
         {
            return typeof(IPermissionManager) == service;
         }
         public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
         {
            return handlers.First(x => x.ComponentModel.Implementation == typeof(PermissionManager));
         }
    }
