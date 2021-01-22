    var shellAppType = Type.GetTypeFromProgID("Shell.Application");
    dynamic shellApp = Activator.CreateInstance(shellAppType);
    var folder = shellApp.NameSpace(folderPath);
    foreach (var item in folder.Items())
    {
        var company = item.ExtendedProperty("Company");
        var author = item.ExtendedProperty("Author");
        // Etc.
    }
