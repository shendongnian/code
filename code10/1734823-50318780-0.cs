    using BitMiracle.LibTiff.Classic;
    . . . .
    public static void ConvertTiffToSKBitmap(MemoryStream tifImage)
    {
		SKColor[] pixels;
		int width, height;
		// open a Tiff stored in the memory stream, and grab its pixels
		using (Tiff tifImg = Tiff.ClientOpen("in-memory", "r", tifImage, new TiffStream()))
		{
			FieldValue[] value = tifImg.GetField(TiffTag.IMAGEWIDTH);
			width = value[0].ToInt();
			value = tifImg.GetField(TiffTag.IMAGELENGTH);
			height = value[0].ToInt();
			// Read the image into the memory buffer 
			int[] raster = new int[width * height];
			if (!tifImg.ReadRGBAImageOriented(width, height, raster, Orientation.TOPLEFT))
			{
				// Not a valid TIF image.
			}
            // store the pixels
			pixels = new SKColor[width * height];
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					int arrayOffset = y * width + x;
					int rgba = raster[arrayOffset];
					pixels[arrayOffset] = new SKColor((byte)Tiff.GetR(rgba), (byte)Tiff.GetG(rgba), (byte)Tiff.GetB(rgba), (byte)Tiff.GetA(rgba));
				}
			}
		}
		using (SKBitmap bitmap = new SKBitmap(width, height))
		{
			bitmap.Pixels = pixels;
			// do something with the SKBitmap
		}
    }
