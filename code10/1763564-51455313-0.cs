    // using System.Windows.Media;
    // using System.Windows.Media.Imaging;
    private void DrawTwoImages()
    {
        // For InputPictureBox
        var file = new Uri("C:\\image.png");
        var inputImage = new BitmapImage(file);
            // If your image is stored in a Resource Dictionary, instead use:
            //     var inputImage = (BitmapImage) Resources["image.png"];
        InputPicture.Source = inputImage;
        // imageCopy isn't actually needed for this example.
        // But since you had it in yours, here is how it's done, anyway.
        var imageCopy = inputImage.Clone();
        // Parameters for setting up our output picture
        int leftMargin   = 50;
        int topMargin    = 5;
        int rightMargin  = 50;
        int bottomMargin = 5;
        int width  = inputImage.PixelWidth  + leftMargin + rightMargin;
        int height = inputImage.PixelHeight + topMargin  + bottomMargin;
        var backgroundColor = Brushes.Black;
        var borderColor = (Pen) null; 
        // Use a DrawingVisual and DrawingContext for drawing
        DrawingVisual dv = new DrawingVisual();
        using (DrawingContext dc = dv.RenderOpen())
        {
            // Draw the black background
            dc.DrawRectangle(backgroundColor, borderColor, new Rect(0, 0, width, height));
            // Copy input image onto output image at desired position
            dc.DrawImage(inputImage, new Rect(leftMargin, topMargin,
                         inputImage.PixelWidth, inputImage.PixelHeight));
        }
        // For displaying output image
        var rtb = new RenderTargetBitmap( width, height, 96, 96, PixelFormats.Pbgra32 );
        rtb.Render(dv);
        OutputPicture.Source = rtb;
    }
