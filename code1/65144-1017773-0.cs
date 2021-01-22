    public class ModuleInstanceCatalog : IModuleInstanceCatalog
    {
         private Dictionary<Type, ModuleBase> _modules = new Dictionary<Type, ModuleBase>();
    
         public void RegisterModuleInstance(ModuleBase module)
         {
             _modules.Add(module.GetType(), module);
         }
    
         public ModuleBase GetModuleInstanceByType(Type type)
         {
             return _modules[type];
         }
    }
