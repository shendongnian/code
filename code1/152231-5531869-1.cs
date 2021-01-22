    CodeNamespace globalNamespace = new CodeNamespace();
    globalNamespace.Imports.Add(new CodeNamespaceImport("Foo"));
            
    // globalNamespace.Comments = string.Empty;    you cannot do this
    ccu.Namespaces.Add(globalNamespace);
    ccu.Namespaces.Add(ns);
