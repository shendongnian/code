    Shader shader = mat.shader;
    for (int i = 0 ; i < ShaderUtil.GetPropertyCount(shader) ; i++) {
        String propertyName = ShaderUtil.GetPropertyName(shader,i);
        ShaderUtil.ShaderPropertyType propertyType = ShaderUtil.GetPropertyType(shader,i);
        
        if (propertyType == ShaderUtil.ShaderPropertyType.TexEnv) {
            Texture tex = mat.GetTexture(propertyName);
            SaveTex(tex);
        }
    }
