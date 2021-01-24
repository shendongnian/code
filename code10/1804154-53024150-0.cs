    public static void ApplyRoundedCorners(Image<Rgba32> img, float cornerRadius)
    {
        IPathCollection corners = BuildCorners(img.Width, img.Height, cornerRadius);
        var graphicOptions = new GraphicsOptions(true) { BlenderMode = PixelBlenderMode.Src };
        img.Mutate(x => x.Fill(graphicOptions, Rgba32.Transparent, corners));
    }
    public static IPathCollection BuildCorners(int imageWidth, int imageHeight, float cornerRadius)
    {
        var rect = new RectangularPolygon(-0.5f, -0.5f, cornerRadius, cornerRadius);
        IPath cornerToptLeft = rect.Clip(new EllipsePolygon(cornerRadius - 0.5f, cornerRadius - 0.5f, cornerRadius));
        var center = new Vector2(imageWidth / 2F, imageHeight / 2F);
        float rightPos = imageWidth - cornerToptLeft.Bounds.Width + 1;
        float bottomPos = imageHeight - cornerToptLeft.Bounds.Height + 1;
        IPath cornerTopRight = cornerToptLeft.RotateDegree(90).Translate(rightPos, 0);
        IPath cornerBottomLeft = cornerToptLeft.RotateDegree(-90).Translate(0, bottomPos);
        IPath cornerBottomRight = cornerToptLeft.RotateDegree(180).Translate(rightPos, bottomPos);
        return new PathCollection(cornerToptLeft, cornerBottomLeft, cornerTopRight, cornerBottomRight);
    }
    private static IImageProcessingContext<Rgba32> ConvertToAvatar(this IImageProcessingContext<Rgba32> processingContext, Size size, float cornerRadius)
    {
        return processingContext.Resize(new ResizeOptions
        {
            Size = size,
            Mode = ResizeMode.Crop
        }).Apply(i => ApplyRoundedCorners(i, cornerRadius));
    }
