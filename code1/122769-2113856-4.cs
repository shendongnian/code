    public class MyViewModel : ViewModel
    {
    
          public ObservableCollection<string> ModuleNames { ... }
          public MyViewModel(IModuleCatalog catalog)
          {
               ModuleNames = new ObservableCollection<string>(catalog.Modules.Select(mod => mod.ModuleName));
          }
    }
