    public interface ITn
    {        
    }
    public class In : Tn
    {
    }
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
       {
           var collection = new ServiceCollection();
           collection.AddSingleton<ITn, Tn>();
           var prov = collection.BuildServiceProvider();
           var tn = prov.GetService(typeof(ITn));
        }
    ...
    }
