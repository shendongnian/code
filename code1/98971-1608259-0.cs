public Image GetThumbnail(int height, int width)
{
    //load the image from a byte array (imageData)
    using (MemoryStream mem = new MemoryStream(this.imageData))
    {
        // Create a Thumbnail from the image
        using (Image thumbPhoto = Image.FromStream(mem, 
            true).GetThumbnailImage(height, width, null, 
            new System.IntPtr()))
        {
            return thumbPhoto;
        }
   }
}
