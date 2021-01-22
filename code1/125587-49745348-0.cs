    using ImageMagick;
    
    string inputPdf= @"C:\my docs\input.pdf";
    string outputPng= @"C:\my docs\output.png";
    
    using (MagickImageCollection images = new MagickImageCollection())
    {
    	images.Read(inputPdf);
    	using (IMagickImage vertical = images.AppendVertically())
    		{
    			vertical.Format = MagickFormat.Png;
                vertical.Density = new Density(300);  
    			vertical.Write(outputPng);
    		}
    }
