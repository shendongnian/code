    Assembly GetAssemblyByName(string name)
    {
        return AppDomain.CurrentDomain.GetAssemblies().
               SingleOrDefault(assembly => assembly.GetName().Name == name);
    }
