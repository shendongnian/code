	/// <summary>
	/// Summary for AssemblyResolver
	/// </summary>
	public ref class AssemblyResolver
	{
    public:
    static Assembly^ MyResolveEventHandler( Object^ sender, ResolveEventArgs^ args )
    {
        Console::WriteLine( "Resolving..." );
        Assembly^ thisAssembly = Assembly::GetExecutingAssembly();
        String^ thisPath = thisAssembly->Location;
        String^ directory = Path::GetDirectoryName(thisPath);
        String^ pathToManagedAssembly = Path::Combine(directory, "managed.dll");
        Assembly^ newAssembly = Assembly::LoadFile(pathToManagedAssembly);
        return newAssembly;
    }
	};
