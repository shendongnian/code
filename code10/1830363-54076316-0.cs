    MemoryStream ms=new MemoryStream();
                        
     ProductImage.CopyTo(ms);
    Image newImage=GetReducedImage(32,32,ms);
    newImage.Save("path+filename");
    public Image GetReducedImage(int Width, int Height, MemoryStream ResourceImage)
            {
                try
                {
                    Image image = Image.FromStream(ResourceImage);
                    Image thumb = image.GetThumbnailImage(Width, Height, () => false, IntPtr.Zero);
    
                    return thumb;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
