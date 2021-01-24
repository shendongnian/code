    public static Texture2D LoadTexture(string filePath)
    {
        Texture2D tex = null;
        if (File.Exists(filePath))
        {
            BMPLoader bmpLoader = new BMPLoader();
            //bmpLoader.ForceAlphaReadWhenPossible = true; //Uncomment to read alpha too
     
            //Load the BMP data
            BMPImage bmpImg = bmpLoader.LoadBMP(filePath);
     
            //Convert the Color32 array into a Texture2D
            tex = bmpImg.ToTexture2D();
        }
        return tex;
    }
