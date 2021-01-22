    public class DrinkReflectionModule : NinjectModule
    {
        private IEnumerable<Assembly> assemblies;
        public DrinkReflectionModule() : this(null) { }
        public DrinkReflectionModule(IEnumerable<Assembly> assemblies)
        {
            this.assemblies = assemblies ??
                AppDomain.CurrentDomain.GetAssemblies();
        }
        public override void Load()
        {
            foreach (Assembly assembly in assemblies)
                RegisterDrinkables(assembly);
        }
        private void RegisterDrinkables(Assembly assembly)
        {
            foreach (Type t in assembly.GetExportedTypes())
            {
                if (!t.IsPublic || t.IsAbstract || t.IsInterface || t.IsValueType)
                    continue;
                if (typeof(IDrinkable).IsAssignableFrom(t))
                    RegisterDrinkable(t);
            }
        }
        private void RegisterDrinkable(Type t)
        {
            Bind<IDrinkable>().To(t)
                .Only(When.ContextVariable("Name").EqualTo(t.Name));
        }
    }
