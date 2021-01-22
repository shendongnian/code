    IO toSearch = nhSession.Get<IO>(5);
    var assembly = Assembly.Load("EntityAssembly");
    IList<Type> assemblyTypes = assembly.GetTypes();
    var searchType = toSearch.GetType();
    var typesThatContainedSearchTypeProperty =
        assemblyTypes.Where(
        ast => ast.GetProperties().Count() > 0 &&
        ast.GetProperties().Where(
            astp => astp.PropertyType != null && astp.PropertyType == searchType).Count() > 0);
