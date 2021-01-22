    using Ninject.Modules;
    class DefaultModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShuriken>().To<BronzeShuriken>();
            Bind<ISword>().To<RustySword>();
        }
    }
