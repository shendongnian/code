    // Reference this in the Inspector
    public RawImage image;
    //...
    pcxFile = File.ReadAllBytes("Assets/5_ImageParser/bagit_icon.pcx");
    int startPoint = 128;
    int height = 152; 
    int width = 152; 
    target = new Texture2D(height, width);
    for (var y = 0; y < height; y++)
    {
        for (var x = 0; x < width; x++)
        {
            timesDone ++;
            pixels[x, y] = new Color(pcxFile[startPoint], pcxFile[startPoint+1], pcxFile[startPoint+2]);
            startPoint += 4;
            target.SetPixel(x, y, pixels[x, y]);
        }            
    }
    target.Apply();
    // You don't need this. Only if you are also going to save it locally
    // as an actual *.jpg file or if you are going to
    // e.g. upload it later via http POST
    //
    // In this case however you would have to asign the result 
    // to a variable in order to use it later
    //var rawJpgBytes = target.EncodeToJPG();
    // Assign the texture to the RawImage component
    image.texture = target;
