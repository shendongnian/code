    System.Drawing.Image imgToResize = null;
    Bitmap bmpImage = null;
    Graphics grphImage = null;
    
    try
    {
        imgToResize = System.Drawing.Image.FromFile ( "image path" );
    
        bmpImage = new Bitmap ( resizeWidth , resizeheight );
        grphImage = Graphics.FromImage ( ( System.Drawing.Image ) bmpImage );
    			
        grphImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
        grphImage.PixelOffsetMode = PixelOffsetMode.HighQuality;
        grphImage.SmoothingMode = SmoothingMode.AntiAlias;
        grphImage.DrawImage ( imgToResize , 0 , 0, resizeWidth , resizeheight );	
    			
        imgToResize.Dispose();	
        grphImage.Dispose();
    
        bmpImage.Save ( "save location" );
    }
    				
    catch ( Exception ex )
    {
       // your exception handler
    }
    finally
    {				
        bmpImage.Dispose();
    }
