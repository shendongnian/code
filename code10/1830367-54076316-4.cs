    Then use the below code 
         
     Stream stream=ProductImage.OpenReadStream();
    Image newImage=GetReducedImage(32,32,stream);
    newImage.Save("path+filename");
    public Image GetReducedImage(int Width, int Height, Stream ResourceImage)
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
