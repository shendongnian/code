        public class ExampleNinjectModule : NinjectModule
        {
            public override void Load()
            {
                Bind<Func<SettingsForm>>().ToMethod( context => () => context.Kernel.Get<SettingsForm>()  );
            }
        }
