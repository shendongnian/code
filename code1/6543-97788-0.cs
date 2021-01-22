    public static ImageData Create(string imageFilename)
    {
       // ...
       ImageDataHeader imageHeader = ParseHeader(imageFilename);
       ImageData newImageData;
       if (imageHeader.bpp == 32)
       {
          newImageData = new ImageData32(imageFilename, imageHeader);
       }
       else
       {
          newImageData = new ImageData16(imageFilename, imageHeader);
       }
       // ...
       return newImageData;
    }
