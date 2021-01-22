    public class MyBaseClassConfigurationModule : IHttpModule {
    
      private System.Collections.Generic.Dictionary<Type, String> typeObjectDefinitionMap;
      public void Dispose() {}
      public void Init(HttpApplication context) {
         context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
      }
      void context_PreRequestHandlerExecute(object sender, EventArgs e) {
        IHttpHandler handler = ((HttpApplication )sender).Context.Handler;
        foreach(Type t in typeObjectDefinitionMap.Keys) {
            if (t.IsAssignableFrom(app.Context.Handler.GetType)) {
                Spring.Context.Support.WebApplicationContext.Current
                  .ConfigureObject(handler, typeObjectDefinitionMap[t]);
            }
        }
      }
    }
