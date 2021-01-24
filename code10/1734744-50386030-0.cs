    static void Main() {
        var thisAssembly = Assembly.GetExecutingAssembly();
        using (var asmFile = File.OpenRead(thisAssembly.Location)) {
            var reader = new PEReader(asmFile);
            var metadata = reader.GetMetadataReader();
            foreach (var methodDefinitionHandle in metadata.MethodDefinitions) {
                var methodDefinition = metadata.GetMethodDefinition(methodDefinitionHandle);
                var methodRVA = methodDefinition.RelativeVirtualAddress;
                // now with PEReader you can resolve your RVA
                var body = reader.GetMethodBody(methodRVA);
                var ilReader = body.GetILReader();
                // ...
            }
        }
    }
