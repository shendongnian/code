    //Set a RawImage in the Inspector
    public RawImage rawImage;
    void Start()
    {
        Texture2D pngImage = LoadPNG(pngPath);
        rawImage.texture = pngImage;
    }
