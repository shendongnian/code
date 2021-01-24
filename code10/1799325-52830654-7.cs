    public static ShaderBytecode CompileShader(string fileName, string entryPoint, string profile, ShaderMacro[] defines = null)
    {
        var shaderFlags = ShaderFlags.None;
        var assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(fileName))
        {
            using (var reader = new StreamReader(stream))
            {
                CompilationResult result = SharpDX.D3DCompiler.ShaderBytecode.Compile(reader.ReadToEnd(),entrypoint,profile,shaderFlags);
                // when the Bytecode == null, means that an error has occurred
                if (result.Bytecode == null)
                    throw new InvalidOperationException(result.Message);
                // removed old code in comment...
                return new ShaderBytecode(result);
            }
        }    
    }
  
