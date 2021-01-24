C#
public bool AddPadding(string filePath)
{
    // Read from file
    using (MagickImage image = new MagickImage(filePath))
    {
        int imageSize = Math.Max(image.Width, image.Height);
        // Add padding
        image.Extent(imageSize, imageSize, Gravity.Center, MagickColors.Purple);
        // Save the result
        image.Write(filePath);
    }
}
This adds a purple padding so you might want to change the color to a different one instead.
