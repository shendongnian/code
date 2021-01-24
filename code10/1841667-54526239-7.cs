    public enum Textures
    {
        Diffuse,
        SemiTransparent,
        Masked
    }
    // initialise the dictionary
    Dictionary<int, Textures> dict;
    dict[TextureConstants.Diffuse] = Textures.Diffuse;
    dict[TextureConstants.SemiTransparent] = Textures.SemiTransparent;
    dict[TextureConstants.Masked] = Textures.Masked;
    
    int someNumber = // ...
    if (dict.TryGetValue (someNumber, out var texture))
    {
        // got one
        if (texture == Textures.Diffuse) // ...
    }
