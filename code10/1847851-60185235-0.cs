BackgroundJob.Enqueue<IService>(service => service.Method(param));
As suggested we need to add an override to the JobActivator used by Hangfire. Hangfire takes the expression and knows it needs a service that implements IService so we just need to tell it how to get that.
Next we need to create a JobActivator as follows:
public class ServiceProviderActivator : JobActivator
{
    private IServiceProvider _serviceProvider;
    public ServiceProviderActivator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public override object ActivateJob(Type jobType)
    {
        return _serviceProvider.GetService(jobType);
    }
}
Now when Hangfire tries to run the job it will require an IService and use the service provider. Now all that is left is to give it the same service provider used by your app.
In ConfigureServices in your Startup file:
services.AddHangfire((serviceProvider, configuration) =>
{
    // other configuration
    configuration.UseActivator(new ServiceProviderActivator(serviceProvider));
});
