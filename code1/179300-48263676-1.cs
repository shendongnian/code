    var assembly = Assembly.GetExecutingAssembly();
    var fileVersionAttribute = assembly.CustomAttributes.FirstOrDefault(ca => ca.AttributeType == typeof(AssemblyFileVersionAttribute));
    if (fileVersionAttribute != null && fileVersionAttribute.ConstructorArguments.Any())
        return fileVersionAttribute.ConstructorArguments[0].ToString().Replace("\"","");
    return string.Empty;
