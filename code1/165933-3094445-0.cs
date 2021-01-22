    int numerator, denominator;
    
    using (Bitmap bmp = (Bitmap)Bitmap.FromFile(@"C:\input.tif"))
    {
        // obtain the XResolution and YResolution TIFFTAG values
        PropertyItem piXRes = bmp.GetPropertyItem(282);
        PropertyItem piYRes = bmp.GetPropertyItem(283);
    
        // values are stored as a rational number - numerator/denominator pair
        numerator = BitConverter.ToInt32(piXRes.Value, 0);
        denominator = BitConverter.ToInt32(piXRes.Value, 4);
        float xRes = numerator / denominator;
    
        numerator = BitConverter.ToInt32(piYRes.Value, 0);
        denominator = BitConverter.ToInt32(piYRes.Value, 4);
        float yRes = numerator / denominator;
    
        // now set the values
        byte[] numeratorBytes = new byte[4];
        byte[] denominatorBytes = new byte[4];
                    
        numeratorBytes = BitConverter.GetBytes(600); // specify resolution in numerator
        denominatorBytes = BitConverter.GetBytes(1);
    
        Array.Copy(numeratorBytes, 0, piXRes.Value, 0, 4); // set the XResolution value
        Array.Copy(denominatorBytes, 0, piXRes.Value, 4, 4);
    
        Array.Copy(numeratorBytes, 0, piYRes.Value, 0, 4); // set the YResolution value
        Array.Copy(denominatorBytes, 0, piYRes.Value, 4, 4);
    
        bmp.SetPropertyItem(piXRes); // finally set the image property resolution
        bmp.SetPropertyItem(piYRes);
    
        bmp.SetResolution(600, 600); // now set the bitmap resolution
                    
        bmp.Save(@"C:\output.tif"); // save the image
    }
