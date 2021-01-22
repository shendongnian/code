    // Get a System.Type from string representation
    Type t = Type.GetType("type name");
    // Create instance of type.
    object o = Activator.CreateInstance(t);
    // Cast it to the interface (or actual Type) you're working with.
    IMyInterface strongObject = (IMyInterface)o;
    // ... and continue from there with the instance.
