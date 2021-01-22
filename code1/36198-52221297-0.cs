     private void _forceAssemblyResolve(Assembly asm) { var dummy = asm.ExportedTypes; }
     var result= Assembly.ReflectionOnlyLoad("Foo");
     _forceAssemblyResolve(result);
    public static Assembly ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
    {
        var childAssembly = _resolve(args);
        _forceAssemblyResolve(childAssembly);
    }
     
