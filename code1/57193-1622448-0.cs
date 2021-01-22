    using System.Drawing;
    using System.Drawing.Imaging;
    
    // The memoryStream contains multi-page TIFF with different
    // variable pixel aspect ratios.
    using (Image img = Image.FromStream(memoryStream)) {
        Guid id = img.FrameDimensionsList[0];
        FrameDimension dimension = new FrameDimension(id);
        int totalFrame = img.GetFrameCount(dimension);
        for (int i = 0; i < totalFrame; i++) {
            img.SelectActiveFrame(dimension, i);
    
            // Faxed documents will have an non-square pixel aspect ratio.
            // If this is the case,adjust the height so that the
            // resulting pixels are square.
            int width = img.Width;
            int height = img.Height;
            if (img.VerticalResolution < img.HorizontalResolution) {
                height = (int)(height * img.HorizontalResolution / img.VerticalResolution);
            }
    
            bitmaps.Add(new Bitmap(img, new Size(width, height)));
        }
    }
