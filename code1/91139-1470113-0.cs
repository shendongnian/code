    using namespace System;
    using namespace System.Reflection;
    void Resolve()
    {
        AppDomain::CurrentDomain->AssemblyResolve +=
            gcnew ResolveEventHandler(OnAssemblyResolve);
    }
    Assembly ^OnAssemblyResolve(Object ^obj, ResolveEventArgs ^args)
    {
    #ifdef _DEBUG
        String ^path = gcnew String(_T("<path to your debug directory>"));
    #else
        String ^path = gcnew String(_T("<path to your release directory>"));
    #endif
        array<String^>^ assemblies =
            System::IO::Directory::GetFiles(path, _T("*.dll"));
        for (long ii = 0; ii < assemblies->Length; ii++) {
            AssemblyName ^name = AssemblyName::GetAssemblyName(assemblies[ii]);
            if (AssemblyName::ReferenceMatchesDefinition(gcnew AssemblyName(args->Name), name)) {
                return Assembly::Load(name);
            }
        }
        return nullptr;
    }
