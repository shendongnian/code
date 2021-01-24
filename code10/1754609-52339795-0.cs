    private void WriteCodeToFile(NamespaceDeclarationSyntax ns)
    {
        var codeAsString = ns.NormalizeWhitespace()
                             .ToFullString();
        
        File.WriteAllText(destFileName, codeAsString);
    }
