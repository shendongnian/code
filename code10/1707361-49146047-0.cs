    private IEnumerable<TypeInfo> GetAllPageTypes()
    {
        var currentAssembly = this.GetType().GetTypeInfo().Assembly;
        var pageTypeInfo = typeof(Page).GetTypeInfo();
        return currentAssembly.DefinedTypes.Where(t => pageTypeInfo.IsAssignableFrom(t)).ToList();
    }
