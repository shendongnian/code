    // Get all the types in your assembly. For testing purpose, I am using Aspose.3D, you can use any.
    var allTypes = Assembly.GetAssembly(typeof(Aspose.ThreeD.Formats.SaveOptions)).GetTypes();
            
    foreach(var myType in allTypes)
    {
        // Check if this type is subclass of your base class
        bool isSubType = myType.IsSubclassOf(typeof(Aspose.ThreeD.Formats.SaveOptions));
        // If it is sub-type, then print its name in Debug window.
        if (isSubType)
        {
            System.Diagnostics.Debug.WriteLine(myType.Name);
        }
    }
