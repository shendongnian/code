    IEnumerable<Assembly> assemblies; // assign the assemblies you want to check here
    foreach (Assembly a in assemblies) {
        foreach (Type t in assembly.GetTypes()) {
            if (t.IsEnum) {
                // found an enum! Do whatever...
            }
        }
    }
