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
