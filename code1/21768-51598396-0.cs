    static void Main(string[] args)
    {
        byte[] data = null;
        string fullPath = @"c:\testimage.jpg";
        
        using (MemoryStream ms = new MemoryStream())
        using (Bitmap tmp = (Bitmap)Bitmap.FromFile(fullPath))
        using (Bitmap bm = new Bitmap(tmp))
        {
        	bm.SetResolution(96, 96);
        	using (EncoderParameters eps = new EncoderParameters(1))
        	{	
        		eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
        		bm.Save(ms, GetEncoderInfo("image/jpeg"), eps);
        	}
        
        	data = ms.ToArray();
        }
        
        File.WriteAllBytes(fullPath, data);
    }
    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
    		ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
    
    		for (int j = 0; j < encoders.Length; ++j)
    		{
    			if (String.Equals(encoders[j].MimeType, mimeType, StringComparison.InvariantCultureIgnoreCase))
    				return encoders[j];
    		}
    	return null;
    }
