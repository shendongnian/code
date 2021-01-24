    public Sample()
    {
        targetUnit = new CodeCompileUnit();
        CodeNamespace samples = new CodeNamespace("CodeDOMSample");
        samples.Imports.Add(new CodeNamespaceImport("System"));
        targetClass = new CodeTypeDeclaration("CodeDOMCreatedClass");
        targetClass.IsClass = true;
        targetClass.TypeAttributes =
            TypeAttributes.Public | TypeAttributes.Sealed;
        samples.Types.Add(targetClass);
        targetUnit.Namespaces.Add(samples);
    }
