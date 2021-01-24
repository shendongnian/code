    public class PayModuleConfig : SlightModuleConfigure
    {
        protected override void Load(IServiceCollection services)
        {
              services.AddTransient<Ipay, PayImp>();
        }
    }
