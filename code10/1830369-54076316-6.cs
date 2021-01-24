     Stream stream=ProductImage.OpenReadStream();
    Image newImage=GetReducedImage(32,32,stream);
    newImage.Save("path+filename");
    public Image GetReducedImage(int width, int height, Stream resourceImage)
            {
                try
                {
                    Image image = Image.FromStream(resourceImage);
                    Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
    
                    return thumb;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
