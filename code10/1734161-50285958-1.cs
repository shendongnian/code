     var assembly = typeof(BaseViewModel).GetTypeInfo().Assembly;
                var types = assembly.DefinedTypes.Where(x => x.BaseType == typeof(BaseViewModel));
    
                foreach (var item in types)
                {
                    var attributes = item.GetCustomAttributes(typeof(DataContractAttribute), false);
                    var dt = attributes.FirstOrDefault() as DataContractAttribute;
                    string dname = dt.Name;
                }
