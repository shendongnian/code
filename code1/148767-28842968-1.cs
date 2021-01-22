	public static bool ResizeImage(string filename, string outputFilename, 
			                        int width, int height, 
                                    InterpolationMode mode = InterpolationMode.HighQualityBicubic)
	{
        using (var bmpOut = ResizeImage(filename, width, height, mode) )
        {
            var imageFormat = GetImageFormatFromFilename(filename);
            if (imageFormat == ImageFormat.Emf)
                imageFormat = bmpOut.RawFormat; 
            bmpOut.Save(outputFilename, imageFormat);
        }
        return true;
	}
