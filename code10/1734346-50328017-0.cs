     public static ConcurrentDictionary<string, Nancy.Session.ISession> Clients = new ConcurrentDictionary<string, Nancy.Session.ISession>();
     protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context){
       base.RequestStartup(container, pipelines, context);
       clients.TryAdd(context.Request.UserHostAddress, context.Request.Session);
    }
