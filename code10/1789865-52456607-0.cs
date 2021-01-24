    private Dictionary<string, Texture> mTextureCache; // initialized in constructor
    public Texture getTexture(file) {
        Texture tex;
        if (mTextureCache.TryGetValue(file, out tex))
            return tex;
        tex = new Texture(file);
        mTextureCache.add(file, tex);
        return tex;
    }
    // Somewhere else in your code:
    Sprite character = new Sprite(getTexture("myCharacter.png"));
