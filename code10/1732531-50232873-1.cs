    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //get all types that implements from all assemlies in the AppDomain
            foreach(var converterType in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => typeof(IValueConverter).IsAssignableFrom(t) 
                    && !t.IsAbstract 
                    && !t.IsInterface))
            {
                //...and add them as resources to <Application.Resources>:
                Current.Resources.Add(converterType.Name, Activator.CreateInstance(converterType));
            }
        }
    }
