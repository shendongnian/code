    static Stream GetImageStream(string imageName) { return ExecutingAssembly.GetManifestResourceStream(imageName); }
    //...
    using (Stream stream = GetImageStream(imageNamespace + filename))
    {
        texture = new Texture2D(0, 0, format, useMipMaps);
        if (!texture.LoadImage(GetImageBuffer(stream)))
            throw new NotSupportedException(filename);
        texture.wrapMode = wrapMode;
        texture.filterMode = filterMode;
    }
    //...
    texture.Apply(true);
    return texture;
