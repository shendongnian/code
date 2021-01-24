        // Get existing project.
    var ssisProject = Project.OpenProject(@"C:\Users\Administrator\Documents\visual studio 2015\projects\Integration Services Project9\Integration Services Project9\bin\Development\Integration Services Project9.ispac");
    // Get existing package.
    Package package = ssisProject.PackageItems["Package.dtsx"].Package;
    // Check the value of Project property of Package.
    // You will notice that Project is not equal to null; which causes problems if you try to add this to another project.
    if (package.Project != null) {
        Console.WriteLine("Original-Package has Project ref: " + package.Project);
    }
    else {
        Console.WriteLine("Original-Package Project ref IS NULL");
    }
    // Create new project.
    Project newProject = Project.CreateProject();
    // Copy the original package. (your original code)
    Package newPackage = package;
    // Check the value of Project property of this Package.
    // You will notice that Project is not equal to null; which causes problems if you try to add this to another project.
    if (newPackage.Project != null) {
        Console.WriteLine("Direct-Copy-Package has Project ref: " + newPackage.Project);
    }
    else {
        Console.WriteLine("Direct-Copy-Package Project ref IS NULL");
    }
    // Let us try to serializ and deserialize using Application class.
    
    // Instantiate an Application object. We will use this to serde the original package.
    Application application = new Application();
    // Save/Seriliaze the original package to disk
    application.SaveToXml(@"C:\Temp\PackageToCopy.dtsx", package, null);
    
    // Load the package back
    Package serdedPackage = application.LoadPackage(@"C:\Temp\PackageToCopy.dtsx", null);
    // Check the value of Project property of this Package.
    // You will notice that Project is equal to null; which means you can add this to another project.
    if (serdedPackage.Project != null) {
        Console.WriteLine("[Before adding to Project] Serded-Package has Project ref: " + serdedPackage.Project);
    }
    else {
        Console.WriteLine("[Before adding to Project] Serded-Package Project ref IS NULL");
    }
    // Add our serded package to newProject.
    newProject.PackageItems.Add(serdedPackage, "NewPackage.dtsx");
    // Now Check the value of Project property of this Serded Package Again
    // You will notice that Project is NOT equal to null again.
    if (serdedPackage.Project != null) {
        Console.WriteLine("[After adding to Project] Serded-Package has Project ref: " + serdedPackage.Project);
    }
    else {
        Console.WriteLine("[After adding to Project] Serded-Package Project ref IS NULL");
    }
    // FInally Save our new project to disk
    newProject.SaveTo(@"C:\Temp\Copy.ispac");
    
    
    Console.WriteLine("Done");
