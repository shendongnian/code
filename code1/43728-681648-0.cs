    StringWriter writer = new StringWriter();
    CSharpCodeProvider provider = new CSharpCodeProvider();
    CodeMemberProperty property = new CodeMemberProperty();
    property.Type = new CodeTypeReference(typeof(int));
    property.Name = "MeaningOfLifeUniverseAndEverything";
    property.GetStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(42)));
    provider.GenerateCodeFromMember(property, writer, null);
    Console.WriteLine(writer.GetStringBuilder().ToString());
