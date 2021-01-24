    static GradientRenderer()
    {
        // This may be changed to GetType()   (see 'The new reflection API')
        var assembly = typeof(GradientRenderer).GetTypeInfo().Assembly;
        //string[] resources = assembly.GetManifestResourceNames();
        string code;
        // use the full filename with namespace
        using (var stream = assembly.GetManifestResourceStream("MirageDX11.Renderers.Gradient.Gradient.hlsl"))
        using (var reader = new StreamReader(stream))
            // read the whole content to a string.
            code = reader.ReadToEnd();
        var shaderFlags = ShaderFlags.None;
    #if DEBUG
        shaderFlags |= ShaderFlags.Debug;
        shaderFlags |= ShaderFlags.SkipOptimization;
    #endif
        // Compile the vertex shader and the pixel shader
        _vertexShaderByteCode = ShaderBytecode.Compile(code, "VS", "vs_5_0", shaderFlags);
        _pixelShaderByteCode = ShaderBytecode.Compile(code, "PS", "ps_5_0", shaderFlags);
    }
