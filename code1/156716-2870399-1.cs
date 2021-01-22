    public static Texture2D GetTexture2DFromBitmap(GraphicsDevice device, Bitmap bitmap)
    {
        Texture2D tex = new Texture2D(device, bitmap.Width, bitmap.Height, 1, TextureUsage.None, SurfaceFormat.Color);
    
        BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
                    
        int bufferSize = data.Height * data.Stride;
    
        //create data buffer 
        byte[] bytes = new byte[bufferSize];    
    
        // copy bitmap data into buffer
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
    
        // copy our buffer to the texture
        tex.SetData(bytes);
    
        // unlock the bitmap data
        bitmap.UnlockBits(data);
    
        return tex;
    }
