    static Assembly^ MyResolveEventHandler( Object^ sender, ResolveEventArgs^ args )
    {
        Console::WriteLine( "Resolving..." );
    
        String^ assemblyName = args->Name;
    
        // Strip irrelevant information, such as assembly, version etc.
        // Example: "Acme.Foobar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
        if( assemblyName->Contains(",") ) 
        {
            assemblyName = assemblyName->Substring(0, assemblyName->IndexOf(","));
        }
    
        Assembly^ thisAssembly = Assembly::GetExecutingAssembly();
        String^ thisPath = thisAssembly->Location;
        String^ directory = Path::GetDirectoryName(thisPath);
        String^ pathToManagedAssembly = Path::Combine(directory, assemblyName );
    
        Assembly^ newAssembly = Assembly::LoadFile(pathToManagedAssembly);
        return newAssembly;
    }
