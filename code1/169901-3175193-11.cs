    // create an array of the various public key tokens used by system assemblies
    byte[][] systemTokens =
        {
            typeof(System.Object)
                .Assembly.GetName().GetPublicKeyToken(),  // B7 7A 5C 56 19 34 E0 89
            typeof(System.Web.HttpRequest)
                .Assembly.GetName().GetPublicKeyToken(),  // B0 3F 5F 7F 11 D5 0A 3A 
            typeof(System.Workflow.Runtime.WorkflowStatus)
                .Assembly.GetName().GetPublicKeyToken()   // 31 BF 38 56 AD 36 4E 35 
        };
    Type typeToTest = GetTypeFromSomewhere();
    string ns = typeToTest.Namespace;
    byte[] token = typeToTest.Assembly.GetName().GetPublicKeyToken();
    bool isSystemType = ((ns == "System") || (ns.StartsWith("System."))
                        && systemTokens.Any(t => t.SequenceEqual(token));
