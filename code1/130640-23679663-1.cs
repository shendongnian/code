    CSharpCodeProvider provider = new CSharpCodeProvider();
    var tw = new IndentedTextWriter(new StreamWriter(filename, false), "    ");
        
    tw.WriteLine("//----------------------------------------------------------------------------");
    tw.WriteLine("// My comments");
    tw.WriteLine("// Are go here");
        
    provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
