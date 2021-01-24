    public class WebApiDependenceResolverProcessor
    {
        public void Process(PipelineArgs args)
        {
            // retrieve container here
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
