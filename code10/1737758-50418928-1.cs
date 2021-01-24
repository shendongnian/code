    public class TypeMapperService
    {
        public Type MapViewModelToView(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewAssemblyName = GetTypeAssemblyName(viewModelType);
            var viewTypeName = GenerateTypeName("{0}, {1}", viewName, viewAssemblyName);
            return Type.GetType(viewTypeName);
        }
    
        public Type MapViewToViewModel(Type viewType)
        {
            var viewModelName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewModelAssemblyName = GetTypeAssemblyName(viewType);
            var viewTypeModelName = GenerateTypeName("{0}Model, {1}", viewModelName, viewModelAssemblyName);
            return Type.GetType(viewTypeModelName);
        }
    
        string GetTypeAssemblyName(Type type) => type.GetTypeInfo().Assembly.FullName;
        string GenerateTypeName(string format, string typeName, string assemblyName) =>
            string.Format(CultureInfo.InvariantCulture, format, typeName, assemblyName);
    }
