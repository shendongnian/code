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
    public void AddFields()
    {
        // Declare the widthValue field.
        CodeMemberField widthValueField = new CodeMemberField();
        widthValueField.Attributes = MemberAttributes.Private;
        widthValueField.Name = "widthValue";
        widthValueField.Type = new CodeTypeReference(typeof(System.Double));
        widthValueField.Comments.Add(new CodeCommentStatement(
            "The width of the object."));
        targetClass.Members.Add(widthValueField);
    
        // Declare the heightValue field
        CodeMemberField heightValueField = new CodeMemberField();
        heightValueField.Attributes = MemberAttributes.Private;
        heightValueField.Name = "heightValue";
        heightValueField.Type =
            new CodeTypeReference(typeof(System.Double));
        heightValueField.Comments.Add(new CodeCommentStatement(
            "The height of the object."));
        targetClass.Members.Add(heightValueField);
    }
    public void GenerateCSharpCode(string fileName)
    {
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        CodeGeneratorOptions options = new CodeGeneratorOptions();
        options.BracingStyle = "C";
        using (StreamWriter sourceWriter = new StreamWriter(fileName))
        {
            provider.GenerateCodeFromCompileUnit(
                targetUnit, sourceWriter, options);
        }
    }
    static void Main()
    {
        Sample sample = new Sample();
        sample.AddFields();
        //sample.AddProperties();
        //sample.AddMethod();
        //sample.AddConstructor();
        //sample.AddEntryPoint();
        sample.GenerateCSharpCode(outputFileName);
    }
