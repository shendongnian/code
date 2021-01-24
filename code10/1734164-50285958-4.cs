    public class BaseViewModel
        {
            public static Dictionary<Assembly, Type> AllAssembelyUsedInBaseViewModel = new Dictionary<Assembly, Type>();
            public static void RegisterAssemblyAndBase(Assembly assembly, Type baseType)
            {
                AllAssembelyUsedInBaseViewModel.Add(assembly, baseType);
            }
            static BaseViewModel()
            {
                RegisterAssemblyAndBase(typeof(BaseViewModel).GetTypeInfo().Assembly, typeof(BaseViewModel));
            }
    
            public static void GetDataContractNameFromAllAssembly()
            {
                List<string> dname = new List<string>();
                foreach (var item in BaseViewModel.AllAssembelyUsedInBaseViewModel)
                {
                    var assembly = item.Key;
                    var types = assembly.DefinedTypes.Where(x => x.BaseType == item.Value);
    
                    foreach (var type in types)
                    {
                        var attributes = type.GetCustomAttributes(typeof(DataContractAttribute), false);
                        var dt = attributes.FirstOrDefault() as DataContractAttribute;
                    if (dt != null)
                    {
                        dname.Add(dt.Name);
                    }
                    }
                }
            }
        }
