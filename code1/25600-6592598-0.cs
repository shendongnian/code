    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using Microsoft.CSharp;
    //...
    private string getFriendlyTypeName(Type type)
    {
        using (var p = new CSharpCodeProvider())
        {
            var r = new CodeTypeReference(type);
            return p.GetTypeOutput(r);
        }
    }
