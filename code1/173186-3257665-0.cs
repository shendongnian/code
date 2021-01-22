    public class ServiceModule : NinjectModule
    {
        public override void Load() {
            Bind<IAccountService>().To<AccountService>();
        }
    }
