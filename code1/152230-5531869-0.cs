    CodeNamespace globalNamespace = new CodeNamespace();
    globalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            
    globalNamespace.Comments = string.Empty;
    ccu.Namespaces.Add(globalNamespace);
    ccu.Namespaces.Add(ns);
