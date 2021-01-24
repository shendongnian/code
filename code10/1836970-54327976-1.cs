    foreach (AttributeData attribute in parameter.GetAttributes())
    {
        if (attribute.AttributeClass.Name == "DontProvideAttribute")
        {
            context.ReportDiagnostic(Diagnostic.Create(DontProvide, reference.Syntax.GetLocation(), parameter.Name));
        }
    }
