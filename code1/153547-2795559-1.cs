    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.Core.Resource;
    using Castle.Windsor;
    using Castle.Windsor.Configuration.Interpreters;
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        WindsorContainer container;
        public WindsorControllerFactory()
        {
            container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));
            var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where typeof(IController).IsAssignableFrom(t)
                                  select t;
            foreach (Type t in controllerTypes)
                container.AddComponentWithLifestyle(t.FullName, t, Castle.Core.LifestyleType.Transient);
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // see http://stackoverflow.com/questions/1357485/asp-net-mvc2-preview-1-are-there-any-breaking-changes/1601706#1601706
            if (controllerType == null) { return null; }
            return (IController)container.Resolve(controllerType);
        }
    }
