    // using System.CodeDom.Compiler;
    CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
    if (provider.IsValidIdentifier (YOUR_VARIABLE_NAME)) {
          // Valid
    } else {
          // Not valid
    }
